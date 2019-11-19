using System;
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

        public override string ToString() => $"{Name} \t {Age}";
    }    
}
