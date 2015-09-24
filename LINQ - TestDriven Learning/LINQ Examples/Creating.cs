using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace LINQ_Examples
{
    [TestClass]
    public class Creating
    {
        /* Creating */
        // It can be achieved by using the IEnumerable static class methods: Range and Repeat
        // They are not extension methods and they do not run in a 'deferred execution' manner
        [TestMethod]
        public void CreatingSequenceUsingRange()
        {
            /* Range */
            // Generates a sequence of integral numbers within a specified range
            var integers = Enumerable.Range(0,10);//This statement will create a sequence of 10 elements 0..9

            var currentNumber = 0;
            foreach (var integer in integers)
            {
                Assert.AreEqual(integer, currentNumber);
                currentNumber++;
            }

            /* Select */
            // Projects the result into any desired sequence
            var integersPlusOne = Enumerable.Range(0, 10).Select(n => n * 2);
            var currentNumberSelect = 0;
            foreach (var integer in integersPlusOne)
            {
                Assert.AreEqual(integer, currentNumberSelect);
                currentNumberSelect += 2;
            }
        }

        [TestMethod]
        public void CreatingSequenceUsingRepeat()
        {
            /* Repeat */
            // Creates a sequence of one value repeated 'n' times
            // The Repeat() method can replicate integers and any object
            var integers = Enumerable.Repeat(5, 10);

            const int repeatedNumber = 5;
            foreach (var integer in integers)
            {
                Assert.AreEqual(integer, repeatedNumber);
            }
        }
    }
}
