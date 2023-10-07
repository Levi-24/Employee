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

            //Implementálj hibakezelést az alkalmazásban, például az adatok beolvasásakor vagy a fájlba írás során.
            //A virtuális metódus segítségével írd ki az összes adatot.


            //Függvény segítségével keresd ki, majd a virtuális metódus segítségével írd ki a legidősebb személy adatait.
            //Függvény segítségével döntsd el, majd a főprogramban írd ki, hogy van - e 50 év fölötti személy, és emellett írd ki a nevét is. (Ez a függvény tehát két értéket kell, hogy generáljon, ezt egyetlen szövegként add vissza a főprogramnak, és a főprogram bontsa szét az adatokat, majd utána írja ki.)
            //Függvénnyel válogasd ki azon személyek nevét egy új tömbbe(nem listába), akik 30 évnél fiatalabbak. Ennek a tömbnek a hasznos tartalmát írd ki a főprogramban.
            //Egyetlen függvénnyel keresd meg a legfiatalabb és a legidősebb személyt. A függvénynek legyen két olyan paramétere, amiben az eredményt vissza lehet juttatni a főprogramba, és ott ki lehet írni a nevüket és a korukat. A függvény visszatérési értéke pedig képes legyen azt jelezni, hogy van-e több ugyanolyan korú legfiatalabb személy.
            //Készíts egy függvényt, ami átszámolja az euróban megadott havi fizetést éves fizetéssé, és az eredményt még váltsd át magyar forintba is.
            //Készíts egy függvényt, amelynek visszatérési értéke egy szótár, amelyben szerepel a 12 millió forint éves fizetés feletti munkavállalók neve és az éves fizetésük forintban. (Az átszámításhoz használd az előző feladat függvényét.)  Az elkészült szótárt a főprogram írja ki egy új fájlba.
            //Írj egy függvényt, aminek a paramétere az eredeti adatokat tartalmazó listának megfelelő típusú. Ennek segítségével számold ki az összes alkalmazott átlagfizetését.
            //Készíts a főprogramban egy olyan listát, amiben csak a developer beosztásúak találhatók, minden tulajdonságukkal. Hívd meg újra a főprogramból az előző függvényt, de most ez az új lista legyen a paramétere. A főprogram írja ki a developerek átlagfizetését.
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


    }
}
