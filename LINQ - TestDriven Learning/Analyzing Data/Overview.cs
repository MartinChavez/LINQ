using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Analyzing_Data
{
    [TestClass]
    public class Overview
    {
        /* Analyzing data using LINQ*/
        /* Totaling 
        - This can be done with the Sum operator
        - Helpful to answer questions such as: "How many programming languages have a rating of 5 ?"  
        */
        /* Grouping and Summing 
        - Allows the analysis of data into groups
        - Helpful to answer questions such as: "How many programming languages that have a rating of 5, have a Type of 'Int'?"  
        */
        /* Mean, Median and Mode
        - Classic data analysis operations
        - Mean: Statistical average
        - Median: Midele number of a set of numbers
        - Mode: Number that occurs the largest number of times
        */

        [TestMethod]
        public void Introduction()
        {
            //Can you use Totaling and Grouping together ?
            const bool answer = true;
            Assert.IsTrue(answer);
        }
    }
}
