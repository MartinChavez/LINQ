using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LINQ_Examples
{
    [TestClass]
    public class Comparing
    {
        /* Comparing */
        // With LINQ, it is possible to compare using the Set Operators, which are extension methods of the Enumerable class
        [TestMethod]
        public void CompareSequences()
        {
            //  Creating our base sequences
            var numbers = Enumerable.Range(0, 10).ToList();
            var squares = Enumerable.Range(0, 10).Select(x => x * x).ToList();

            /* Intersect */
            // Produces the set intersection of two sequences (defining the elements that are common to both sequences)
            var intersect = numbers.Intersect(squares).ToList();
            var expectedIntersect = new[] { 0, 1, 4, 9 };

            for (var index = 0; index < expectedIntersect.Length; index++)
                Assert.AreEqual(expectedIntersect[index], intersect[index]);


            /* Except */
            // Produces the set difference of two sequences (defining the elements on one sequence, that are not in the other)
            var except = numbers.Except(squares).ToList();
            var expectedExcept = new[] { 2, 3, 5, 6, 7, 8 };

            for (var index = 0; index < expectedExcept.Length; index++)
                Assert.AreEqual(expectedExcept[index], except[index]);

            /* Concat */
            // Produces the sequence that is the result of merginf two sequences


            /* Distinct */
            // Returns distinct elements of a sequence


            /* Union */
            // Produces the set Union of two sequences (defining the unique items from merging two sequences)



        }

    }
}
