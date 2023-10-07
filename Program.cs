using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Employee
{
    class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>();
            using StreamReader sr = new StreamReader(
                path: @"..\..\..\src\Person.txt",
                Encoding.UTF8
                );
            while (!sr.EndOfStream)
            {
                persons.Add(new Person(sr.ReadLine()));
                _ = sr.ReadLine();
            }

            int i = 0;
            foreach (var person in persons)
            {
                person.Print(i, persons);
                i++;
            }

            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine($"1.Feladat: {Math.Round(AverageAge(persons),2)}");
            Console.WriteLine($"2.Feladat: {CityCount(persons)}");
            var oldest = FindOldest(persons);
            for (int j = 0; j < persons.Count; j++)
            {
                if (persons[j] == oldest) oldest.PrintOldest(oldest);
            }
            Console.WriteLine($"4.Feladat: {Over50(persons)}");
            Console.WriteLine("5.Feladat:");
            foreach (var person in Under30(persons)) Console.WriteLine($"\t{person}");
            Person youngest;
            Person oldest2;
            bool moreYoung = YoungestOldest(persons, out youngest, out oldest2);
            Console.WriteLine($"6.Feladat: Legfiatalabb neve: {youngest.Name} \t Legidosebb neve: {oldest2.Name} \n\t Van több ugyanolyan korú legfiatalabb személy? {moreYoung}");
            Console.WriteLine($"7.Feladat:");
            var yearlyHufList = new List<int>();
            foreach (var person in persons) 
            {
                Console.WriteLine(YearlyHuf(person));
                yearlyHufList.Add(YearlyHuf(person));
            }
            Console.WriteLine($"8.Feladat: Kiirva");
            Dictionary<string, int> keyValuePairs = Over12Million(persons,yearlyHufList);

            using StreamWriter writer = new StreamWriter(
                path: @"..\..\..\src\12_000_000_Salary",
                append: false,
                Encoding.UTF8
                );
            foreach (var kvp in keyValuePairs)
            {
                writer.WriteLine($"\tNév: {kvp.Key} \tÉves fizetés: {kvp.Value}");
            }

            Console.WriteLine($"9.Feladat: Az átlagfizetés 2. tizedesjegyre kerekitve: {Math.Round(AverageSalary(persons),2)}");

            var Developers = new List<Person>();
            foreach (var person in persons)
            {
                if (person.Position == "Developer")
                {
                    Developers.Add(new Person(person));
                }
            }

            Console.WriteLine($"10.Feladat: {AverageSalary(Developers)}");

            //Implementálj hibakezelést az alkalmazásban, például az adatok beolvasásakor vagy a fájlba írás során.
            var xd = AverageGenderSalary(persons);
            Console.WriteLine($"11.Feladat: Male: {xd[0]}; \t Female: {xd[1]};");
        }
        static double AverageAge(List<Person> persons)
        {
            double average = persons.Average(p => p.Age);
            return average;
        }

        static int CityCount(List<Person> persons)
        {
            int count = persons.Count(p => p.City == "Budapest");
            return count;
        }

        static Person FindOldest(List<Person> persons)
        {
            var oldest = persons.OrderBy(p => p.Age).Last();
            return oldest;
        }

        static string Over50(List<Person> persons)
        {
            var over50age = persons.Any(p => p.Age > 50);
            Person over50;
            if (over50age)
            {
                over50 = persons.Find(p => p.Age > 50);
                return $"Van 50 év feletti alkalmazott, a neve: {over50.Name}";
            }
            else return "Nincsen 50 év feletti alkalmazott.";
        }

        static string[] Under30(List<Person> persons)
        {
            int arraySize = persons.Count(p => p.Age < 30);
            string[] under30names = new string[arraySize];

            var under30 = persons.Where(p => p.Age < 30);
            int i = 0;
            foreach (var person in under30)
            {
                under30names[i] = person.Name;
                i++;
            }

            return under30names;
        }

        static bool YoungestOldest(List<Person> persons, out Person youngest, out Person oldest)
        {
            youngest = persons.OrderBy(p => p.Age).First();
            oldest = persons.OrderBy(p => p.Age).Last();

            var youngestCopy = persons.OrderBy(p => p.Age).First();

            int i = 0;
            foreach (var person in persons) if (person.Age == youngestCopy.Age) i++;

            bool moreYoung = false;
            if (i > 1) moreYoung = true;
            return moreYoung;
        }

        static int YearlyHuf(Person person)
        {
            return (person.Salary * 12) * 388;
        }

        static Dictionary<string,int> Over12Million(List<Person> persons, List<int> yearlyHufSalary)
        {
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();

            int i = 0;
            foreach (var person in persons)
            {
                if (yearlyHufSalary[i] > 12000000) 
                {
                    keyValuePairs.Add(person.Name, yearlyHufSalary[i]);
                }
                i++;
            }

            return keyValuePairs;
        }

        static double AverageSalary(List<Person> persons)
        {
            double average = persons.Average(p => p.Salary);
            return average;
        }

        static double[] AverageGenderSalary(List<Person> persons)
        {
            double[] average = { persons.Where(p => p.Gender).Average(p => p.Salary), persons.Where(p => p.Gender == false).Average(p => p.Salary) };
            return average;
        }
    }
}
