LINQ : Test-Driven Learning
================

A project aimed to help the user master LINQ with a test-driven approach. Each unit contains an annotated tutorial on the code and the ability to run Unit Tests to verify the expected behavior.

Topics
================
 - Basics

Tools
====================
<a name="README">[<img src="http://www.codeproject.com/KB/cross-platform/860150/vs2015.png" width="50px" height="50px" />](https://www.visualstudio.com/en-us/products/vs-2015-product-editions.aspx)</a>

Suggested prerequisites
====================
<a name="README">[<img src="https://s3-us-west-2.amazonaws.com/testdrivenlearningbucket/csharp7.png" width="50px" height="50px" />](https://github.com/MartinChavez/CSharp)</a>

Basics
====================
```CSharp
        [TestMethod]
        public void Introduction()
        {
            /* Language Integrated Query (LINQ)
            - Extends powerful query capabilities to the language syntax of C#. 
            - LINQ introduces standard, easily-learned patterns for querying and updating data, and the technology can be extended to support potentially any kind of data store
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
```
