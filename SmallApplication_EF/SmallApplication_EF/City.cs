using System.Collections.Generic;

namespace SmallApplication_EF
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public List<Person> Persons { get; set; } = new List<Person>();
    }
}