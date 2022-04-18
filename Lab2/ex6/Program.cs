using System;

namespace ex6
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age) 
        {
            Name = name;
            Age = age;
        }

        public override string ToString() 
        {
            return "\nName: " + Name + "\nAge: " + Age;
        }

    }
    public class Citizen : Person {
        public String City { get; set; }

        public Citizen(string name, int age, String city) 
            : base(name, age)
        {
            City = city;
        }

        public override string ToString()
        {
            return base.ToString() +
                   "\nCity: " + City;
        }
    }
    
    public class Employee : Citizen 
    {
        public string Work { get; set; }
        public int Salary { get; set; }

        public Employee(string name, int age, String city, string work, int salary)
            : base(name, age, city) 
        {
            Work = work;
            Salary = salary;
        }

        public override string ToString()
        {
            return base.ToString() +
                   "\nWork: " + Work + "\nSalary: " + Salary;
        }
    }
    public class Student : Citizen
    {
        public int Clas { get; set; }

        public Student(string name, int age, String city, int clas)
            : base(name, age, city) 
        {
            Clas = clas;
        }

        public override string ToString()
        {
            return base.ToString() +
                   "\nClass: " + Clas;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Person[] a = { new Citizen("Alex", 18,"Kharkiv"),
                new Employee("Vlad", 20, "Kiev", "Analitics",1500),
                new Student("Roma", 16, "Lviv", 9)};
            foreach (Person person in a)
            {
                System.Console.WriteLine(person);
            }
        }
    }
}