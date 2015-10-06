using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace Analyzing_Data
{
    [TestClass]
    public class Totaling
    {
  
        [TestMethod]
        public void CalculateTotalUsingSumOperator()
        {
            /* Sum Operator */
            // Extension method used to calculate the sum of every item on a list, when defining a property for such calculation
            /* Parameter:
            - Selector: Defines the property that is used for the calculation
            */

            // Getting the total 'Market Share' from all of the programming languages
            var totalMarketShare = ProgrammingLanguageRepository.GetProgrammingLanguages().Sum(pg => pg.MarketShare);
              
            Assert.AreEqual(totalMarketShare,100);
        }
    }
}
