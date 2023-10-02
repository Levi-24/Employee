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

        public virtual void Print()
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
        }
    }
}
