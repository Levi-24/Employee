﻿using System;
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

            //Implementálj hibakezelést az alkalmazásban, például az adatok beolvasásakor vagy a fájlba írás során.


            //Egyetlen függvénnyel keresd meg a legfiatalabb és a legidősebb személyt.
            //A függvénynek legyen két olyan paramétere, amiben az eredményt vissza lehet juttatni a főprogramba, és ott ki lehet írni a nevüket és a korukat.
            //A függvény visszatérési értéke pedig képes legyen azt jelezni, hogy van-e több ugyanolyan korú legfiatalabb személy.

            //Készíts egy függvényt, ami átszámolja az euróban megadott havi fizetést éves fizetéssé, és az eredményt még váltsd át magyar forintba is.

            //Készíts egy függvényt, amelynek visszatérési értéke egy szótár, amelyben szerepel a 12 millió forint éves fizetés feletti munkavállalók neve és az éves fizetésük forintban.
            //(Az átszámításhoz használd az előző feladat függvényét.)  Az elkészült szótárt a főprogram írja ki egy új fájlba.

            //Írj egy függvényt, aminek a paramétere az eredeti adatokat tartalmazó listának megfelelő típusú. Ennek segítségével számold ki az összes alkalmazott átlagfizetését.

            //Készíts a főprogramban egy olyan listát, amiben csak a developer beosztásúak találhatók, minden tulajdonságukkal.
            //Hívd meg újra a főprogramból az előző függvényt, de most ez az új lista legyen a paramétere. A főprogram írja ki a developerek átlagfizetését.

            //Számold ki a férfi és női alkalmazottak átlagfizetését tetszőleges módszerrel.
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
    }
}
