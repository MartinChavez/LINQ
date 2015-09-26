﻿using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace LINQ_Examples
{
    [TestClass]
    public class Projections
    {
        /* Projections */
        // Refers to the operation of transforming an object into a new form
        // The results are projected using the LINQ operators Select or SelectMany
        [TestMethod]
        public void ProjectwithSelect()
        {
            var programmingLanguages = ProgrammingLanguageRepository.GetProgrammingLanguages().ToList();

            /* Select */
            // Projects values that are based on a transform function, the transformation is often defined with a Lamda expression
            // It projects each item in the sequence into the new Type, in this case, it is a String
            var onlyNames = programmingLanguages.Select(pg => pg.Name).ToList(); 

            Assert.AreEqual(onlyNames.First(),"C#");
            Assert.AreEqual(onlyNames.Last(), "Ruby");

            // It is possible to Project into an anonymous Type, it can be created directly in the Lamda expression
            var onlyNamesAndRankings = programmingLanguages.Select(pg => 
            // The 'new' keyword defines the anonymous Type
            new
            {
                ProgrammingLanguageName = pg.Name,
                // For single fields, it is not necessary to specify the name of the property if you want to preserve the original name
                pg.Rating
            }).ToList();

            Assert.AreEqual(onlyNamesAndRankings.First().ProgrammingLanguageName, "C#");
            Assert.AreEqual(onlyNamesAndRankings.First().Rating, 10);
            Assert.AreEqual(onlyNamesAndRankings.Last().ProgrammingLanguageName, "Ruby");
            Assert.AreEqual(onlyNamesAndRankings.Last().Rating, 7);
        }

        [TestMethod]
        public void JoinLists()
        {
            var programmingLanguages = ProgrammingLanguageRepository.GetProgrammingLanguages().ToList();
            var programmingLanguageTypes = ProgrammingLanguageTypeRepository.GetProgrammingLanguageTypes().ToList();

            /* Join */
            // Allows to combine the desired data into one query and tranform the results into a new Type
            // The caller(programmingLanguages) is considered the outer list
            // The parameter(programmingLanguageTypes) is considered the inner list
            /* 
            Parameters:
            - outerKeySelector: Key selector that is used to match the columns on the join from the outer list
            - innerKeySelector: Key selector that is used to match the columns on the join from the inner list
            - resultSelector: Select delegate used for projection
            */
            var programmingLanguagesAndTypes = programmingLanguages.Join(programmingLanguageTypes, pl => pl.TypeId, plt => plt.TypeId, (pl, plt) => new
            {
                pl.Name, plt.Type
            }).ToList();

            Assert.AreEqual(programmingLanguagesAndTypes.First().Name, "C#");
            Assert.AreEqual(programmingLanguagesAndTypes.First().Type, "Object Oriented");
            Assert.AreEqual(programmingLanguagesAndTypes.Last().Name, "Ruby");
            Assert.AreEqual(programmingLanguagesAndTypes.First().Type, "Object Oriented");
        }
    }
}