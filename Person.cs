using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Employee
{
    class Person
    {
        //A forrás fájlban a mezők jelentése: name, age, city, department, position, gender, marital status, salary (EUR)
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public bool Gender { get; set; }
        public bool MaritalStatus { get; set; }
        public int Salary { get; set; }

        public Person (string ReadLine)
        {
            var Pieces = ReadLine.Split(';');
            this.Name = Pieces[0];
            this.Age = int.Parse(Pieces[1]);
            this.City = Pieces[2];
            this.Department = Pieces[3];
            this.Position = Pieces[4];
            this.Gender = Pieces[5] == "Male";
            this.MaritalStatus = Pieces[6] == "Married";
            this.Salary = int.Parse(Pieces[7]);
        }

        public Person (Person person)
        {
            this.Name = person.Name;
            this.Age = person.Age;
            this.City = person.City;
            this.Department = person.Department;
            this.Position = person.Position;
            this.Gender = person.Gender;
            this.MaritalStatus = person.MaritalStatus;
            this.Salary = person.Salary;
        }

        public virtual void Print(int i, List<Person> persons)
        {
            Console.Write($"{persons[i].Name}; ");
            Console.Write($"{persons[i].Age}; ");
            Console.Write($"{persons[i].City}; ");
            Console.Write($"{persons[i].Department}; ");
            Console.Write($"{persons[i].Position}; ");
            Console.Write($"{persons[i].Gender}; ");
            Console.Write($"{persons[i].MaritalStatus}; ");
            Console.WriteLine($"{persons[i].Salary}; ");
        }

        public virtual void PrintOldest(Person person)
        {
            Console.WriteLine($"3.Feladat: {person.Name} {person.Age}");
        }
    }
}
