using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class ProgrammingLanguageRepository
    {
        public ProgrammingLanguage Find(IEnumerable<ProgrammingLanguage> programmingLanguages, int programmingLanguageId)
        {
            return programmingLanguages.FirstOrDefault(programmingLanguage => programmingLanguage.Id == programmingLanguageId);
        }

        public List<ProgrammingLanguage> GetProgrammingLanguages()
        {
            List<ProgrammingLanguage> programmingLanguages = new List<ProgrammingLanguage>
                    {new ProgrammingLanguage()
                          { Id = 1,
                            Name= "C#",
                       },
                    new ProgrammingLanguage()
                          {  Id = 2,
                            Name= "Javascript"
                    },
                    new ProgrammingLanguage()
                          { Id = 3,
                            Name= "Java"
                    },
                    new ProgrammingLanguage()
                          {  Id = 4,
                            Name= "Python"
                    },
                     new ProgrammingLanguage()
                          {  Id = 5,
                            Name= "C"
                    },
                      new ProgrammingLanguage()
                          {  Id = 6,
                            Name= "Objective-C"
                    },
                        new ProgrammingLanguage()
                          {  Id = 6,
                            Name= "Ruby"
                    }
            };
            return programmingLanguages;
        }
    }
}
