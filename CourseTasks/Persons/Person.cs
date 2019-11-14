using System;
using System.Collections.Generic;
using System.Globalization;

namespace Lyambda
{
    class Person
    {
        public Person(string name, int age)
        {
            if (age < 0 || age > 150)
            {
                throw new ArgumentOutOfRangeException("Invalid value of age", nameof(age));
            }

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            Name = textInfo.ToTitleCase(name);
            Age = age;
        }

        public string Name
        {
            get;
            set;
        }

        public int Age
        {
            get;
            set;
        }

        private bool CheckName(string name)
        {
            foreach (var symbol in name)
            {
                if (Char.IsNumber(symbol))
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString() => $"{Name} \t {Age}";

        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Person person = (Person)obj;

            return Name == person.Name && Age == person.Age;
        }

        public override int GetHashCode() => Age.GetHashCode() ^ Name.GetHashCode();
    }

    class AgeComparer : IComparer<Person>
    {
        public int Compare(Person person1, Person person2) => person2.Age.CompareTo(person1.Age);
    }
}
