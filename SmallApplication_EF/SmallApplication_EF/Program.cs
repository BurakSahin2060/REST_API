using Microsoft.EntityFrameworkCore;
using SmallApplication_EF;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new DBContext())
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            bool fertig = false;

            while (!fertig)
            {
                Console.WriteLine("Neue Person eingeben:");

                Console.Write("Vorname: ");
                string firstName = Console.ReadLine();

                Console.Write("Nachname: ");
                string lastName = Console.ReadLine();

                Console.Write("Alter: ");
                int age;
                while (!int.TryParse(Console.ReadLine(), out age))
                {
                    Console.Write("Ungültige Eingabe. Bitte Zahl eingeben: ");
                }

                Console.Write("Stadt: ");
                string cityName = Console.ReadLine();

                var city = context.Cities.FirstOrDefault(c => c.Name == cityName);
                if (city == null)
                {
                    city = new City { Name = cityName, People = new List<Person>() };
                    context.Cities.Add(city);
                    context.SaveChanges();
                }

                var person = new Person
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    CityId = city.Id
                };

                context.People.Add(person);
                context.SaveChanges();

                Console.Write("\nMöchtest du noch eine Person hinzufügen? (ja/nein): ");
                string antwort = Console.ReadLine().Trim().ToLower();
                if (antwort == "nein" || antwort == "n")
                {
                    fertig = true;
                }

                Console.WriteLine();
            }

            var cities = context.Cities.Include(c => c.People).ToList();

            Console.WriteLine("\nAlle Daten in der Datenbank:");
            foreach (var c in cities)
            {
                Console.WriteLine($"Stadt: {c.Name}");
                foreach (var p in c.People)
                {
                    Console.WriteLine($"- {p.FirstName} {p.LastName}, Alter: {p.Age}");
                }
            }
        }
    }
}
