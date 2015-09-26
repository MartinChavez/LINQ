using System.Collections.Generic;

namespace Models
{
    public static class ProgrammingLanguageTypeRepository
    {
        public static IEnumerable<ProgrammingLanguageType> GetProgrammingLanguageTypes()
        {
            var programmingLanguagesTypes = new List<ProgrammingLanguageType>
                    {new ProgrammingLanguageType()
                          { TypeId = 1,
                            Type = "Object Oriented"
                       },
                    new ProgrammingLanguageType()
                          {  TypeId = 2,
                             Type = "Imperative"
                    },
                    new ProgrammingLanguageType()
                          {  TypeId = 3,
                             Type = "Functional"
                    }
            };
            return programmingLanguagesTypes;
        }
    }
}
