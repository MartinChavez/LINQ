﻿using System.Collections.Generic;

namespace Models
{
    public static class ProgrammingLanguageRepository
    {
        public static IEnumerable<ProgrammingLanguage> GetProgrammingLanguages()
        {
            var programmingLanguages = new List<ProgrammingLanguage>
                    {new ProgrammingLanguage()
                          { Id = 1,
                            Name = "C#",
                            Rating = 10,
                            TypeId = 1,
                            ObjectTypes = new List<ObjectType> { new ObjectType { Id = 1, Name = "String"} , new ObjectType { Id = 2, Name = "Int" } }
                       },
                    new ProgrammingLanguage()
                          {  Id = 2,
                            Name= "Javascript",
                            Rating = 7,
                            TypeId = 1,
                              ObjectTypes = new List<ObjectType> { new ObjectType { Id = 1, Name = "Float"} , new ObjectType { Id = 2, Name = "String" } }
                    },
                    new ProgrammingLanguage()
                          { Id = 3,
                            Name= "Java",
                            Rating = 3,
                            TypeId = 1,
                              ObjectTypes = new List<ObjectType> { new ObjectType { Id = 1, Name = "String"} , new ObjectType { Id = 2, Name = "Int" }, new ObjectType { Id = 2, Name = "Float" } }
                    },
                    new ProgrammingLanguage()
                          {  Id = 4,
                             Name= "Python",
                             Rating = 7,
                             TypeId = 1
                    },
                     new ProgrammingLanguage()
                          {  Id = 5,
                             Name= "C",
                             Rating = 8,
                             TypeId = 2
                    },
                      new ProgrammingLanguage()
                          {  Id = 6,
                             Name= "F#",
                             Rating = 10,
                             TypeId = 3
                    },
                      new ProgrammingLanguage()
                          {  Id = 7,
                             Name= "Objective-C",
                             Rating = 6,
                             TypeId = 1
                    },
                        new ProgrammingLanguage()
                          {  Id = 8,
                             Name= "Ruby",
                             Rating = 7,
                             TypeId = 1,
                              ObjectTypes = new List<ObjectType> { new ObjectType { Id = 1, Name = "String"} , new ObjectType { Id = 2, Name = "Int" }, new ObjectType { Id = 2, Name = "Float" } }
                    }     

            };
            return programmingLanguages;
        }
    }
}
