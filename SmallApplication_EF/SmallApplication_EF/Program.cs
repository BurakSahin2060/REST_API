using System;

namespace SmallApplication_EF

class Program
{
    static void Main(string[] args)
    {
        using (var context = new AppDbContext())
        {
            context.Database.EnsureCreated();

            context.People.Add(new Person { Name = "Max", Age = 17 });
            context.People.Add(new Person { Name = "Anna", Age = 18 });
            context.SaveChanges();

            Console.WriteLine("Gespeicherte Personen:");
            foreach (var person in context.People)
            {
                Console.WriteLine($"ID: {person.Id}, Name: {person.Name}, Alter: {person.Age}");
            }
        }

        Console.WriteLine("Drücken Sie eine Taste zum Beenden...");
        Console.ReadKey();
    }
}