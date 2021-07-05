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
    class Program
    {
        private static bool doDebugCode = false;
        [Conditional("DEBUG")]
        static void Main(string[] args)
        {
            // Declare people List
            List<Person> people = new List<Person>();

            string line;
            StreamReader inFile;

            // Read the file and display it line by line
            
            if (args.Length == 1)
            {
                inFile = new StreamReader(args[0]);
            }
            else
            {
                Console.WriteLine("Please run app in commandline using 'name-sorter.exe .\\filename.txt");
                Console.WriteLine("Press Enter to exit...");
                Console.ReadLine();
                if (doDebugCode)
                {
                    inFile = new StreamReader(@".\unsorted-names-list.txt");

                }
                inFile = null;
                System.Environment.Exit(0);
            }

            while ((line = inFile.ReadLine()) != null)
            {
                if (line != "")
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
            
            PrintNamesAndWriteFile(sortedPeople);
        }

        public static void PrintArrayIndexAndValues(IEnumerable list)
        {
            int i = 0;
            foreach (var item in list)
            {
                Console.WriteLine($"[{i++}]:   {item}");
            }
        }

        public static void PrintNamesAndWriteFile(IEnumerable list)
        {
            StreamWriter outFile = new StreamWriter(@".\sorted-names-list.txt");
            
            foreach(var item in list)
            {
                Console.WriteLine(item);
                outFile.WriteLine(item);
            }
            outFile.Close();
        }

        
    
        public void TestPersonImportFromString(string _string)
        {
            // take "Given Name Surname" and end up with a <Person> with
            // Givenname="Given name" and Surname="Surname"
            string[] names = _string.Split();
            Person person = new Person() { GivenName = String.Join(" ", names, 0, (names.Length - 1)), Surname = names[names.Length - 1] };
            string personString = person.ToString();
            Debug.Assert(personString == "Given name Surname");
        }

        public void TestPrintingFullNamesToConsole(List<Person> people)
        {
            foreach (var item in people)
            {
                // Print the Person's full name, formatted correctly
            }
        }

        public void ReadLinesFromTextFile(StreamReader inFile)
        {
            // For each line in inFile, print the string to the Console
        }

        public void AddPeopleFromTextFile(StreamReader inFile)
        {
            // For each line in inFile, run ImportFromString,
            // add the result to a List<Person>
        }


    }
        


}
