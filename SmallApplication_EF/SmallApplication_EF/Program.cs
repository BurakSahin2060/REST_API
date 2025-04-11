using Microsoft.EntityFrameworkCore;
using SmallApplication_EF;
using System;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DBContext>();
        optionsBuilder.UseSqlite("Data Source=people.db");

        using (var context = new DBContext(optionsBuilder.Options))
        {
            // Datenbank initialisieren
            await context.Database.EnsureCreatedAsync();

            bool fertig = false;

            while (!fertig)
            {
                try
                {
                    Console.WriteLine("Neue Person eingeben:");

                    Console.Write("Vorname: ");
                    string firstName = Console.ReadLine()?.Trim();
                    if (string.IsNullOrWhiteSpace(firstName))
                    {
                        Console.WriteLine("Vorname darf nicht leer sein.");
                        continue;
                    }

                    Console.Write("Nachname: ");
                    string lastName = Console.ReadLine()?.Trim();
                    if (string.IsNullOrWhiteSpace(lastName))
                    {
                        Console.WriteLine("Nachname darf nicht leer sein.");
                        continue;
                    }

                    Console.Write("Alter: ");
                    if (!int.TryParse(Console.ReadLine(), out int age) || age < 0)
                    {
                        Console.WriteLine("Ungültiges Alter. Bitte eine positive Zahl eingeben.");
                        continue;
                    }

                    Console.Write("Stadt: ");
                    string cityName = Console.ReadLine()?.Trim();
                    if (string.IsNullOrWhiteSpace(cityName))
                    {
                        Console.WriteLine("Stadtname darf nicht leer sein.");
                        continue;
                    }

                    // Case-insensitive Suche
                    var city = await context.Cities
                        .FirstOrDefaultAsync(c => c.Name.ToLower() == cityName.ToLower());

                    if (city == null)
                    {
                        city = new City { Name = cityName };
                        context.Cities.Add(city);
                    }

                    var person = new Person
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        City = city
                    };

                    context.People.Add(person);
                    await context.SaveChangesAsync(); // Einmaliges Speichern

                    Console.Write("\nMöchtest du noch eine Person hinzufügen? (ja/nein): ");
                    string antwort = Console.ReadLine()?.Trim().ToLower();
                    if (antwort == "nein" || antwort == "n")
                    {
                        fertig = true;
                    }

                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ein Fehler ist aufgetreten: {ex.Message}");
                }
            }

            // Daten anzeigen
            var cities = await context.Cities
                .Include(c => c.People)
                .OrderBy(c => c.Name)
                .ToListAsync();

            Console.WriteLine("\nAlle Daten in der Datenbank:");
            if (cities.Count == 0)
            {
                Console.WriteLine("Keine Daten vorhanden.");
            }
            else
            {
                foreach (var c in cities)
                {
                    Console.WriteLine($"Stadt: {c.Name}");
                    if (c.People.Count == 0)
                    {
                        Console.WriteLine("- Keine Personen in dieser Stadt.");
                    }
                    else
                    {
                        foreach (var p in c.People.OrderBy(p => p.LastName))
                        {
                            Console.WriteLine($"- {p.FirstName} {p.LastName}, Alter: {p.Age}");
                        }
                    }
                }
            }
        }
    }
}