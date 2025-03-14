namespace _01_MyFirstWebApplication
{
    public class Person
    {
        public string Geschlecht
        {
            get => Geschlecht;
            set
            {
                if (Geschlecht != "männlich" || Geschlecht != "weiblich")
                {
                    Console.WriteLine("Ungültiges Geschlecht eingegeben!");
                }
            }
        }
        public DateTime Geburtstag { get; set; }
        public Person(DateTime geburtstag, string geschlecht)
        {
            Geburtstag = geburtstag;
            Geschlecht = geschlecht;
        }
    }
}
