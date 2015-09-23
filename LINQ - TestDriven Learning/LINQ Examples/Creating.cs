using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace LINQ_Examples
{
    [TestClass]
    public class Creating
    {
        /* Creating */
        // LINQ Provides a set of ordering operators that allow you to order a squence of objects by one or more criteria
        // The execution of a query expression using these operators is defered until the code request an item from the resulting sequence
        [TestMethod]
        public void OrderingByKeySelector()
        {
            var programmingLanguages = ProgrammingLanguageRepository.GetProgrammingLanguages();

            /* OrderBy */
            // The parameter for OrderBy is a KeySelector, which is the filed to use as the key for the sorting
            var orderedProgrammingLanguages = programmingLanguages.OrderBy(programmingLanguage => programmingLanguage.Name);

            Assert.IsTrue(orderedProgrammingLanguages.First().Name == "C");
            Assert.IsTrue(orderedProgrammingLanguages.Last().Name == "Ruby");
        }

     
    }
}
