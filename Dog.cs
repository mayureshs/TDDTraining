using System;

namespace DogClasses
{
    public class Dog
    {
        private string name;
        private int age;

        public  Dog(String name, int age)
        {
            Name = name;
            Age = age;
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; } 
            set { age = value; }
        }

        public int HumanAge
        {
            get { return Age*Name.Length; }
        }

    }
}