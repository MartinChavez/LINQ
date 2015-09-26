using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LINQ_Examples
{
    [TestClass]
    public class ComparingAndCombining
    {
        /* Comparing and Combining*/
        // With LINQ, it is possible to compare and combine using the Set Operators, which are extension methods of the Enumerable class
        [TestMethod]
        public void CompareSequences()
        {
            //  Creating our base sequences
            var numbers = Enumerable.Range(0, 10).ToList();                    // 0 ,1, 2, 3, 4,  5,  6,  7,  8,  9
            var squares = Enumerable.Range(0, 10).Select(x => x * x).ToList(); // 0 ,1, 4, 9, 16, 25, 36, 49, 64, 81

            /* Intersect */
            // Produces the set intersection of two sequences (defining the elements that are common to both sequences)
            var intersect = numbers.Intersect(squares).ToList();
                var expectedIntersect = new[] { 0, 1, 4, 9 };

            for (var index = 0; index < expectedIntersect.Length; index++)
                Assert.AreEqual(expectedIntersect[index], intersect[index]);

            /* Except */
            // Produces the set difference of two sequences (defining the elements on one sequence that are not in the other)
            var except = numbers.Except(squares).ToList();
            var expectedExcept = new[] { 2, 3, 5, 6, 7, 8 };

            for (var index = 0; index < expectedExcept.Length; index++)
                Assert.AreEqual(expectedExcept[index], except[index]);

            /* Concat */
            // Produces the sequence that is the result of merging two sequences (including duplicates)
            var concat = numbers.Concat(squares).ToList();
            var expectedConcat = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 4, 9, 16, 25, 36, 49, 64, 81 };

            for (var index = 0; index < expectedConcat.Length; index++)
                Assert.AreEqual(expectedConcat[index], concat[index]);

            /* Distinct */
            // Returns distinct elements of a sequence
            var distinct = numbers.Concat(squares).Distinct().ToList();
            var expectedDistinct= new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 16, 25, 36, 49, 64, 81 };

            for (var index = 0; index < expectedDistinct.Length; index++)
                Assert.AreEqual(expectedDistinct[index], distinct[index]);

            /* Union */
            // Produces the set Union of two sequences (defining the unique items from merging two sequences)
            // Equivalent to the use of Concat().Distinct()
            var union = numbers.Union(squares).ToList();
            var expectedUnion = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 16, 25, 36, 49, 64, 81 };

            for (var index = 0; index < expectedUnion.Length; index++)
                Assert.AreEqual(expectedUnion[index], union[index]);
        }
    }
}
