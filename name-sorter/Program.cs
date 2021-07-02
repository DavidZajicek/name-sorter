using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace name_sorter
{
    public class Person
    {
        public string GivenName { get; set; }
        public string Surname { get; set; }

        public override string ToString()
        {
            return GivenName + " " + Surname;
        }
    }
        class Program
    {
        static void Main(string[] args)
        {
            // Declare people List
            List<Person> people = new List<Person>();
            // Add people to people List
            people.Add(new Person() { GivenName = "Abdul Jafar", Surname = "Vader" });
            people.Add(new Person() { GivenName = "Adbul Jafar", Surname = "Vader" });
            people.Add(new Person() { GivenName = "Abdul Jafar", Surname = "Cader" });

            Console.WriteLine("List of names before sorting:");
            PrintArrayIndexAndValues(people);
            // Using LINQ to compare strings within list by sorting by surname, and then given name
            IEnumerable<Person> sortedPeople = people.OrderBy(person => person.Surname).ThenBy(person => person.GivenName);
            Console.WriteLine("List of names after a default sort: (Surname only)");
            PrintArrayIndexAndValues(sortedPeople);
        }

        public static void PrintArrayIndexAndValues(IEnumerable list)
        {
            int i = 0;
            foreach (var item in list)
            {
                Console.WriteLine($"[{i++}]:   {item}");
            }
        }
    }



}
