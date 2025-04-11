using System.Collections.Generic;

namespace SmallApplication_EF
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Person> People { get; set; } = new List<Person>();
    }
}