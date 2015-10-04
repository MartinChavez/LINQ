using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace Analyzing_Data
{
    [TestClass]
    public class MeanMedianAndMode
    {

        /* Measures */
        /*
        - Mean: Defines the statistical average of a set of numbers
        - Median: Defines the middle number of a set of sorted numbers, it is generally used to calculate the Average on a set with extreme outliers
        - Mode: Number that occurs the largest number of times
        */

        [TestMethod]
        public void CalculateMeanUsingAverage()
        {
            /* Mean (using Average)*/
            /* Parameter:
            - Selector: Defines the property that is used to calculate the average
            */
            var meanRating = ProgrammingLanguageRepository.GetProgrammingLanguages().Average(pg => pg.Rating);

            Assert.AreEqual(meanRating, 7.25);
        }

        [TestMethod]
        public void CalculateMedianUsingOrderBy()
        {
            /* Median (using GroupBy) */
            // To calculate the Median:
            // It is necessary to calculate the middle entry in a set, 
            // If there is an even number of entries, the middle two entries are averaged

            // First, we sort our list by Rating to perform the calculations
            var sortedProgrtammingLanguges = ProgrammingLanguageRepository.GetProgrammingLanguages().OrderBy(pg => pg.Rating);

            var count = sortedProgrtammingLanguges.Count();
            var position = count / 2;

            int medianRating;
            if ((count % 2) == 0)
            {
                medianRating = (sortedProgrtammingLanguges.ElementAt(position).Rating +
                                sortedProgrtammingLanguges.ElementAt(position - 1).Rating) / 2;
            }
            else
            {
                medianRating = sortedProgrtammingLanguges.ElementAt(position).Rating;
            }

            Assert.AreEqual(medianRating, 7);
        }


        [TestMethod]
        public void CalculateMode()
        {
            /* Mode (using GroupBy and OrderByDescending) */
            // To calculate the Mode:
            // It is necessary to group by each value and
            // count the number in each group
            var modeRating = ProgrammingLanguageRepository.GetProgrammingLanguages().GroupBy
                (pg => pg.Rating).OrderByDescending(group => group.Count()).Select(group => group.Key).FirstOrDefault();

            Assert.AreEqual(modeRating, 7);
        }
    }
}
