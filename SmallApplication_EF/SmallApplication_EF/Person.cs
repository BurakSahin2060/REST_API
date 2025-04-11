using SmallApplication_EF;
using System.ComponentModel.DataAnnotations;

namespace SmallApplication_EF
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string PLZ { get; set; } = null!;

        public City City { get; set; } = null!;
    }
}
