using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace Analyzing_Data
{
    [TestClass]
    public class GroupingAndSumming
    {
        /* GroupBy 
        - Operator used to group the data and perform analysis
        - Single Property
        - Multiple Properties
        - Parent Property
       */

        [TestMethod]
        public void GroupingBySingleProperty()
        {
            // GroupBy (Single Property)
            /* Parameters:
            - KeySelector: Defines the key to use for the grouping
            - elementSelector: Defines the values to select from the list
            - resultSelector: Defines the shape or form of the results
            */

            // Comparing the Market share of programming languages that 'DerivedFromC' vs the ones that don't
            var marketShare = ProgrammingLanguageRepository.GetProgrammingLanguages().GroupBy(pg => pg.DerivedFromC, pg => pg.MarketShare, (groupKey, marketShareTotal) => new
            {
                Key = groupKey,
                MarketShare = marketShareTotal.Sum()
            }).ToList();
            Assert.AreEqual(marketShare.First().MarketShare, 70);  // Key = true
            Assert.AreEqual(marketShare.Last().MarketShare, 30);   // Key = false
        }

        [TestMethod]
        public void GroupingByMultipleProperties()
        {
            // GroupBy (Multiple Properties)
            /* Parameters:
            - KeySelector: Defines the key to use for the grouping, in this case, we create an anonymous Type of two properties
            - elementSelector: Defines the values to select from the list
            - resultSelector: Defines the shape or form of the results
            */

            // Comparing the Market share of programming languages that 'DerivedFromC', grouping by the ones that contain 'C'
            var marketShare = ProgrammingLanguageRepository.GetProgrammingLanguages().GroupBy(
                pg => new
                {
                    pg.DerivedFromC,
                    NameContainsC = pg.Name.Contains('C')

                }, pg => pg.MarketShare, (groupKey, marketShareTotal) => new
                {
                    Key = "Derives From C :" + groupKey.DerivedFromC + " , Name contains 'C' : " + groupKey.NameContainsC,
                    MarketShare = marketShareTotal.Sum()
                }).ToList();

            // Three results (total):
            Assert.AreEqual(marketShare.First().Key, "Derives From C :True , Name contains 'C' : True"); //  MarketShare = 39
            Assert.AreEqual(marketShare[1].Key, "Derives From C :True , Name contains 'C' : False"); //  MarketShare = 31
            Assert.AreEqual(marketShare.Last().Key, "Derives From C :False , Name contains 'C' : False");  //  MarketShare = 30
        }

        [TestMethod]
        public void GroupingByParentData()
        {
            // GroupBy (Parent Property)
         
            var programmingLanguages = ProgrammingLanguageRepository.GetProgrammingLanguages().ToList();
            var programmingLanguageTypes = ProgrammingLanguageTypeRepository.GetProgrammingLanguageTypes().ToList();


            var programmingLanguagesTypeQuery = programmingLanguages.Join(programmingLanguageTypes, pg => pg.TypeId,
                pgt => pgt.TypeId,(pl,plt) => new
                {
                    // We save an instance of the programming language to access the properties on the future
                    ProgrammingLanguageInstance = pl,
                    ProgrammingLanguageType = plt
                });


            // Getting the Market share of programming languages, Ordering by programming language Type name
            var programmingLanguagesMarketShare = programmingLanguagesTypeQuery.GroupBy(
                pg => pg.ProgrammingLanguageType, pg => pg.ProgrammingLanguageInstance.MarketShare, (groupKey, marketShareTotal) => new
                {
                    Key = groupKey.Type,
                    MarketShare = marketShareTotal.Sum()
                }).ToList();

            // Three results (total):
            Assert.AreEqual(programmingLanguagesMarketShare.First().Key, "Object Oriented");
            Assert.AreEqual(programmingLanguagesMarketShare.First().MarketShare, 77);

            Assert.AreEqual(programmingLanguagesMarketShare[1].Key, "Imperative");
            Assert.AreEqual(programmingLanguagesMarketShare[1].MarketShare, 4);

            Assert.AreEqual(programmingLanguagesMarketShare.Last().Key, "Functional");
            Assert.AreEqual(programmingLanguagesMarketShare.Last().MarketShare, 19);
        }
    }
}
