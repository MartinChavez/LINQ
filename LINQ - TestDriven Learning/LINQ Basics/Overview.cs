using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace LINQ_Basics
{
    [TestClass]
    public class Overview
    {
        [TestMethod]
        public void Introduction()
        {
            /* Language Integrated Query (LINQ)
            - Extends powerful query capabilities to the language syntax of C#. 
            - LINQ introduces standard, easily-learned patterns for querying and updating data, and the technology can be extended to support potentially any kind of data store.
            */
            /*
            LINQ can be used when working with:
            - Lists
            - Binding Data
            - Generating Summary Data
            - Working with Strings
            - Working with Dates
            - Executing code stored in an object
            */

            /* Data Sources */
            // LINQ woks with providers that allow data retrieval
            /*
            - LINQ to SQL
            - LINQ to Entities
            - LINQ to Objects
            - LINQ to XML
            */

            //LINQ makes a query a first-class language construct in C# ?
            const bool answer = true;
            Assert.IsTrue(answer);
        }

        [TestMethod]
        public void Syntax()
        {
            /* LINQ Syntax
            - There are two ways of writing LINQ Queries:
            - Query Syntax 
            - Method Syntax
            */
            /* Query syntax
            - Declarative form to invoke the LINQ Operators
            - Similar to a SQL statement
            */
            /* Method syntax
            - Invokes the LINQ operators using methods
            */

            //Is the Query syntax semantically identical to the Method syntax?
            const bool answer = true;
            Assert.IsTrue(answer);
        }

        [TestMethod]
        public void FindItemWithForeachIterator()
        {
            var programmingLanguageRepository = new ProgrammingLanguageRepository();
            var programmingLanguages = programmingLanguageRepository.GetProgrammingLanguages();

            /* Normal Foreach iteration */
            ProgrammingLanguage csharp = null;
            /* Iterating over the loop and finding the programming language 'C#'*/
            foreach (var programmingLanguage in programmingLanguages)
            {
                if (programmingLanguage.Name == "C#")
                {
                    csharp = programmingLanguage;
                }
            }
            Assert.IsNotNull(csharp);
            Assert.IsTrue(csharp.Name == "C#");
        }

        [TestMethod]
        public void FindItemWithLinqQueryExpressions()
        {
            var programmingLanguageRepository = new ProgrammingLanguageRepository();
            var programmingLanguages = programmingLanguageRepository.GetProgrammingLanguages();

            /* Query Expression */
            // A query expression operates on one or more data sources by applying one or more query operators
            // The syntax contains SQL-like operators: from, where and select

            // from: defines the source of the data
            // programmingLanguage: references each iterated element
            // programmingLanguages: defines the data source (it must implement IEnumerable)
            // where: it is used to define the filter
            // select: projects each element of the resulting sequence into a new form
            var query = from programmingLanguage in programmingLanguages
                        where programmingLanguage.Name == "C#"
                        select programmingLanguage;

            // The First() method returns the first element of the sequence
            var csharp = query.First();

            /*Note: 
            - LINQ uses defered execution, this means that the 'query' statement only defines the LINQ statement
            - The LINQ query is not executed until its result is required
            - Calling an operator on the query will cause the query to execute, in this case, is the First() method
            */
            Assert.IsNotNull(csharp);
            Assert.IsTrue(csharp.Name == "C#");
        }
    }
}
