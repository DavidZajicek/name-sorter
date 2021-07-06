using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;

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
    public class Program
    {
        private static bool doDebugCode = false;
        [Conditional("DEBUG")]

        public static void Main(string[] args)
        {
            // Initialise variables
            List<Person> people = new List<Person>();
            StreamReader inFile;

            // Check if a filename argument was given, then assign to inFile
            inFile = ImportNamesFile(args[0]);

            // Read the file and return a list of people
            people = AddPeopleToListFromFile(inFile);

            // Using LINQ to compare strings within list by sorting by surname, and then given name
            IEnumerable<Person> sortedPeople = people.OrderBy(person => person.Surname).ThenBy(person => person.GivenName);
            Console.WriteLine("List of names after a default sort: (Surname only)");

            PrintNamesAndWriteFile(sortedPeople); 
        }


        public static StreamReader ImportNamesFile(string[] args)
        {
            StreamReader inFile;
            if (args.Length == 1)
            {
                inFile = new StreamReader(args);
            }

            else // Exit App Early if no filename given
            {
                Console.WriteLine("Please run app in commandline using 'name-sorter.exe .\\filename.txt");
                Console.WriteLine("Press Enter to exit...");
                //Console.ReadLine();
                if (doDebugCode)
                {
                    inFile = new StreamReader(@".\unsorted-names-list.txt");
                }
                inFile = null;
                System.Environment.Exit(0);
            }
            return inFile;
        }


        static List<Person> AddPeopleToListFromFile(StreamReader inFile)
        {
            string line;
            List<Person> people = new List<Person>();

            while ((line = inFile.ReadLine()) != null)
            {
                if (line != "")
                {
                    var names = line.Split();
                    people.Add(new Person() { GivenName = String.Join(" ", names, 0, (names.Length - 1)), Surname = names[names.Length - 1] });
                }

            }
            return people;
        }


        public static void PrintNamesAndWriteFile(IEnumerable list)
        {
            StreamWriter outFile = new StreamWriter(@".\sorted-names-list.txt");

            foreach (var item in list)
            {
                Console.WriteLine(item);
                outFile.WriteLine(item);
            }
            outFile.Close();
        }

    }
}
