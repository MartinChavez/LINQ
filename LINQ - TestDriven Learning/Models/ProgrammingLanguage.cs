using System.Collections.Generic;

namespace Models
{
    public class ProgrammingLanguage
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public int TypeId { get; set; }
        public bool DerivedFromC { get; set; }
        public List<ObjectType> ObjectTypes { get; set; }
        public decimal MarketShare { get; set; }
    }
}
