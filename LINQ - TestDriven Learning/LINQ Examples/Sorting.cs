using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace LINQ_Examples
{
    [TestClass]
    public class Sorting
    {
        /* Sorting */
        // LINQ Provides a set of ordering operators that allow you to order a sequence of objects by one or more criteria
        // The execution of a query expression using these operators is deferred until the code request an item from the resulting sequence
        [TestMethod]
        public void OrderingByKeySelector()
        {
            var programmingLanguages = ProgrammingLanguageRepository.GetProgrammingLanguages();

            /* OrderBy */
            // The parameter for OrderBy is a KeySelector, which is the field to use as the key for the sorting
            var orderedProgrammingLanguages = programmingLanguages.OrderBy(programmingLanguage => programmingLanguage.Name);

            Assert.IsTrue(orderedProgrammingLanguages.First().Name == "C");
            Assert.IsTrue(orderedProgrammingLanguages.Last().Name == "Ruby");
        }

        [TestMethod]
        public void OrderingUsingTwoConditions()
        {
            var programmingLanguages = ProgrammingLanguageRepository.GetProgrammingLanguages();
            /* ThenBy */
            // Allows a secondary sort apart from OrderBy
            // The parameter for ThenBy is a KeySelector
            var orderedProgrammingLanguages = programmingLanguages.OrderBy(programmingLanguage => programmingLanguage.Rating).ThenBy(programmingLanguage => programmingLanguage.Name);
            // Note: It is possible to create several filters by using chaining, as long as the first method is 'OrderBy' followed by a series of 'ThenBy'

            Assert.IsTrue(orderedProgrammingLanguages.First().Name == "Java");
            Assert.IsTrue(orderedProgrammingLanguages.Last().Name == "F#");
        }

        [TestMethod]
        public void SortingInReverseUsingOrderByDescending()
        {
            var programmingLanguages = ProgrammingLanguageRepository.GetProgrammingLanguages();

            /* OrderByDescending */
            // Allows to reverse a sequence of items by using a KeySelector
            var orderedProgrammingLanguages = programmingLanguages.OrderByDescending(programmingLanguage => programmingLanguage.Rating);

            Assert.IsTrue(orderedProgrammingLanguages.First().Name == "C#");
            Assert.IsTrue(orderedProgrammingLanguages.Last().Name == "Java");
        }

        [TestMethod]
        public void SortingInReverseUsingReverse()
        {
            var programmingLanguages = ProgrammingLanguageRepository.GetProgrammingLanguages();

            /* Reverse */
            // Functionally identical to OrderByDescending but uses a different syntax
            var orderedProgrammingLanguages = programmingLanguages.OrderBy(programmingLanguage => programmingLanguage.Rating).Reverse().ToList();

            // Reverse sets 'F#' as the first value since it has a rating of 10, same as C#
            Assert.IsTrue(orderedProgrammingLanguages.First().Name == "F#");
            Assert.IsTrue(orderedProgrammingLanguages.Last().Name == "Java");
        }

        [TestMethod]
        public void SortingWithNullValues()
        {
            var programmingLanguages = ProgrammingLanguageRepository.GetProgrammingLanguages().ToList();
            // Adding a new programming language with null values
            programmingLanguages.Add(new ProgrammingLanguage()
            {
                Id = null,
                Name = null,
                Rating = 0
            });

            /* Sorting with Null Values */
            // The 'null' values will always be sorted to the top of the list
            var orderedByNullOnTop = programmingLanguages.OrderBy(programmingLanguage => programmingLanguage.Name);

            Assert.IsNull(orderedByNullOnTop.First().Name);

            /* HasValue */
            // It allows to control where the 'null' values are in the sort by verifying that the property has a value
            var orderedByNullOnTheBottom = programmingLanguages.OrderByDescending(programmingLanguage => programmingLanguage.Id.HasValue);

            Assert.IsNull(orderedByNullOnTheBottom.Last().Id);
        }
    }
}
