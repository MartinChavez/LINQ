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
            - LINQ introduces a standard, easily-learned patterns for querying and updating data, and the technology can be extended to support potentially any kind of data store.
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

            // LINQ Defines a set of general purpose standard query operators that allow:
            /*
            - Transversal
            - Filter
            - Projection
            */
            // Queries can be applied to any data source that is based on a Type that implements IEnumerable<T>

            //LINQ makes a query a first-class language construct in C# ?
            const bool answer = true;
            Assert.IsTrue(answer);
        }

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

        [TestMethod]
        public void FindItemWithForeachIterator()
        {
            var programmingLanguages = ProgrammingLanguageRepository.GetProgrammingLanguages();

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
        public void FindItemWithLinqQuerySyntax()
        {
            var programmingLanguages = ProgrammingLanguageRepository.GetProgrammingLanguages();

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
            - LINQ uses deferred execution, this means that the 'query' statement only defines the LINQ statement
            - The LINQ query is not executed until its result is required
            - Calling an operator on the query will cause the query to execute, in this case, is the First() method
            */
            Assert.IsNotNull(csharp);
            Assert.IsTrue(csharp.Name == "C#");
        }

        [TestMethod]
        public void FindItemWithLinqMethodSyntax()
        {
            var programmingLanguages = ProgrammingLanguageRepository.GetProgrammingLanguages();

            /* LINQ extension methods */
            // The extension methods extend any Type that implements the IEnumerable interface

            /* The First() extension method:
            - Returns the first element of the sequence
            - The First() method will throw an exception if no match is found
            */
            /* The First() method has two overloads:
            - The first overload method passes no parameters and returns the first element of a sequence
            - The second overload allows defining criteria, it returns the first element in a sequence that satisfies a specific condition
                - First(Func<ProgrammingLanguage,bool> predicate) overload defines a delegate (reference to a function)
            */

            /* Lambda expression */
            // It is an in-line(defined in the extension method parameter) anonymous function

            // programmingLanguage: represents the parameter, in other words, represents each programming language as the sequence is iterated
            // => : represents the Lambda operator, it separates the parameters from the expression itself
            // programmingLanguage.Name == "C#": represents the body of the function
            // when the condition is met, the Lamda fuction returns 'true' and 'First()' returns the object
            var csharp = programmingLanguages.First(programmingLanguage => programmingLanguage.Name == "C#");

            Assert.IsNotNull(csharp);
            Assert.IsTrue(csharp.Name == "C#");
        }

        [TestMethod]
        public void FailToFindItemWithFirstOrDefault()
        {
            var programmingLanguages = ProgrammingLanguageRepository.GetProgrammingLanguages();
            /* FirstOrDefault */
            // Finds the first entry on the list, but if no entry is found, it returns the default value of the list object, which in most reference Types is 'null'
            var cplusplus = programmingLanguages.FirstOrDefault(programmingLanguage => programmingLanguage.Name == "C++");

            Assert.IsNull(cplusplus);
        }

        [TestMethod]
        public void FindSeveralItemsWithLinqMethodSyntax()
        {
            var programmingLanguages = ProgrammingLanguageRepository.GetProgrammingLanguages();
            /* Where */
            // Where is the extension method that is used to find multiple entries
            // It also recieves a Lambda expression as a parameter
            var foundLanguages =
                programmingLanguages.Where(
                    // It is a good practice to cache the query result by simply adding a ToList() or ToArray() after LINQ so that the query result is saved(cached)
                    // Otherwise, you will enumerate the collection every time you execute a LINQ statement on 'programmingLanguages'
                    programmingLanguage => programmingLanguage.Name == "C#" || programmingLanguage.Name == "Java").ToList();

            Assert.AreEqual(foundLanguages.First().Name, "C#");
            // Chaining: Extension methods can be chained together
            // Skip() - allows to fluently(via chaining) skip one entry
            Assert.AreEqual(foundLanguages.Skip(1).First().Name, "Java");
        }
    }
}
