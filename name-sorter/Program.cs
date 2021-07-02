﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

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

            string line;
            
            // Read the file and display it line by line
            StreamReader file = new StreamReader(@".\unsorted-names-list.txt");
            while((line = file.ReadLine()) != null)
            {
                if(line != "") // Ignore empty lines
                {
                    var names = line.Split();
                    people.Add(new Person() { GivenName = String.Join(" ", names, 0, (names.Length - 1)), Surname = names[names.Length-1] });
                }
            }


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
