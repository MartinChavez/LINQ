<a name="slides">[<img src="https://s3-us-west-2.amazonaws.com/testdrivenlearningbucket/linqblack.png" width="200px" height="200px"/>](http://martinchavez.github.io/LINQ)</a>

LINQ: Test-Driven Learning
================

This project is aimed to help the user further study LINQ with a test-driven approach. Each unit contains an annotated tutorial and a platform where you can test your understanding of the topic.

## Overview
 - LINQ Query Syntax
 - LINQ Method Syntax
 - LINQ Extension methods
 - Lambda expressions
 - First() and FirstOrDefault()
 - Where()
 
## Sorting
 - OrderBy()
 - ThenBy()
 - OrderByDescending()
 - Reverse()
 - Sorting with null values

## Creating
 - Range()
 - Repeat()
 
## Comparing and Combining
 - Intersect
 - Except
 - Concat
 - Distinct
 - Union

## Projection
 - Select()
 - Join()
 - SelectMany()
 
## Totaling
 - Sum operator
 
## Grouping and Summing
 - GroupBy(Single property)
 - GroupBy(Multiple Properties)
 - GroupBy(Parent Property)

## Measures 
 - Mean (using Average)
 - Median (using GroupBy) 
 - Mode (using GroupBy and OrderByDescending)

Tools
====================
<a name="README">[<img src="http://www.codeproject.com/KB/cross-platform/860150/vs2015.png" width="50px" height="50px" />](https://www.visualstudio.com/en-us/products/vs-2015-product-editions.aspx)</a>

Suggested prerequisites
====================
<a name="README">[<img src="https://s3-us-west-2.amazonaws.com/testdrivenlearningbucket/CSHARP.png" width="50px" height="50px" />](https://github.com/MartinChavez/CSharp)</a>

#Overview
```C#
       /* Language Integrated Query (LINQ) 
        - Adds query capabilities to the language syntax of C#. 
        - LINQ introduces standard, easy to learn patterns for querying and updating data, which can be extended to support potentially any kind of data store.
       */
         
       /* LINQ Syntax:
        - There are two ways of writing LINQ Queries:
        - Query Syntax 
        - Method Syntax
        */
        /* Query syntax:
        - Uses the declarative form to invoke the LINQ Operators
        - Similar to an SQL statement
        */
        /* Method syntax:
        - Invokes the LINQ operators using methods
        */

        [TestMethod]
        public void FindItemWithLinqQuerySyntax()
        {
            var programmingLanguages = ProgrammingLanguageRepository.GetProgrammingLanguages();

            /* Query Expression */
            // A query expression operates on one or more data sources by applying one or more query operators
            // The syntax contains SQL-like operators: 'from', 'where', and 'select'

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
            - Calling an operator on the query will cause the query to execute. In this case, it is the First() method.
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

            // programmingLanguage: represents the parameter. In other words, it represents each programming language as the sequence is iterated
            // => : represents the Lambda operator, it separates the parameters from the expression itself
            // programmingLanguage.Name == "C#": represents the body of the function
            // when the condition is met, the Lambda fuction returns 'true' and 'First()' returns the object
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
```

#Sorting
```C#
        /* Sorting */
        // LINQ Provides a set of ordering operators that allow you to order a sequence of objects by one or more criteria
        // The execution of a query expression using these operators is deferred until the code requests an item from the resulting sequence
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
```
#Comparing and Combining
```C#
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
```

#Grouping and Summing
```C#
       /* GroupBy 
        - Is an operator used to group the data and perform analysis
        - Single Property
        - Multiple Properties
        - Parent Property
       */

        [TestMethod]
        public void GroupingBySingleProperty()
        {
            // GroupBy (Single Property)
            /* Parameters:
            - KeySelector: Defines the key to use for the grouping
            - elementSelector: Defines the values to select from the list
            - resultSelector: Defines the shape or form of the results
            */

            // Comparing the Market share of programming languages that 'DerivedFromC' vs the ones that don't
            var marketShare = ProgrammingLanguageRepository.GetProgrammingLanguages().GroupBy(pg => pg.DerivedFromC, pg => pg.MarketShare, (groupKey, marketShareTotal) => new
            {
                Key = groupKey,
                MarketShare = marketShareTotal.Sum()
            }).ToList();
            Assert.AreEqual(marketShare.First().MarketShare, 70);  // Key = true
            Assert.AreEqual(marketShare.Last().MarketShare, 30);   // Key = false
        }

        [TestMethod]
        public void GroupingByMultipleProperties()
        {
            // GroupBy (Multiple Properties)
            /* Parameters:
            - KeySelector: Defines the key to use for the grouping. In this case, we create an anonymous Type of two properties.
            - elementSelector: Defines the values to select from the list
            - resultSelector: Defines the shape or form of the results
            */

            // Comparing the Market share of programming languages that 'DerivedFromC', grouping by the ones that contain 'C'
            var marketShare = ProgrammingLanguageRepository.GetProgrammingLanguages().GroupBy(
                pg => new
                {
                    pg.DerivedFromC,
                    NameContainsC = pg.Name.Contains('C')

                }, pg => pg.MarketShare, (groupKey, marketShareTotal) => new
                {
                    Key = "Derives From C :" + groupKey.DerivedFromC + " , Name contains 'C' : " + groupKey.NameContainsC,
                    MarketShare = marketShareTotal.Sum()
                }).ToList();
```
Run and Play
====================
Open, edit, run the tests and start learning!

<img src="https://s3-us-west-2.amazonaws.com/testdrivenlearningbucket/linqTests.png"/>

Contact
====================
[<img src="https://s3-us-west-2.amazonaws.com/martinsocial/MARTIN2.png" />](http://martinchavezaguilar.com/)
[<img src="https://s3-us-west-2.amazonaws.com/martinsocial/github.png" />](https://github.com/martinchavez)
[<img src="https://s3-us-west-2.amazonaws.com/martinsocial/mail.png" />](mailto:info@martinchavezaguilar.com)
[<img src="https://s3-us-west-2.amazonaws.com/martinsocial/linkedin.png" />](https://www.linkedin.com/in/martinchavezaguilar)
[<img src="https://s3-us-west-2.amazonaws.com/martinsocial/twitter.png" />](https://twitter.com/martinchavezag)

Continue Learning
====================
<a name="README">[<img src="https://s3-us-west-2.amazonaws.com/martinbucket/JS.png" width="50px" height="50px" />](https://github.com/MartinChavez/Learn-Javascript)</a>
<a name="README">[<img src="https://pbs.twimg.com/profile_images/2149314222/square.png" width="50px" height="50px" />](https://github.com/MartinChavez/AngularJs-Basics)</a>
<a name="README">[<img src="https://s3-us-west-2.amazonaws.com/testdrivenlearningbucket/angularadvanced.png" width="50px" height="50px" />](https://github.com/MartinChavez/AngularJS-Advanced-Topics)</a>
<a name="README">[<img src="https://s3-us-west-2.amazonaws.com/testdrivenlearningbucket/CSHARP.png" width="50px" height="50px" />](https://github.com/MartinChavez/CSharp)</a>
<a name="README">[<img src="https://s3-us-west-2.amazonaws.com/testdrivenlearningbucket/linqblack.png" width="50px" height="50px" />](https://github.com/MartinChavez/LINQ)</a>
<a name="README">[<img src="http://precision-software.com/wp-content/uploads/2014/04/jQurery.gif" width="50px" height="50px" />](https://github.com/MartinChavez/jQueryBasics)</a>
<a name="README">[<img src="https://s3-us-west-2.amazonaws.com/testdrivenlearningbucket/htmlcss.jpg" width="65px" height="50px" />](https://github.com/MartinChavez/HTML-CSS)</a>
<a name="README">[<img src="https://s3-us-west-2.amazonaws.com/testdrivenlearningbucket/htmlcssblack.jpg" width="65px" height="50px" />](https://github.com/MartinChavez/HTML-CSS-Advanced-Topics)</a>
