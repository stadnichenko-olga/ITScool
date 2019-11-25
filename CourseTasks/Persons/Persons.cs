using System;
using System.Collections.Generic;
using System.Linq;

namespace Lyambda
{
    class Persons
    {
        static void Main(string[] args)
        {
            var personsList = new List<Person>
            {
                new Person("Andrew", 20),
                new Person("Ann Brown", 16),
                new Person("Andrew", 27),
                new Person("Alex", 20),
                new Person("Hew", 89),
                new Person("Kir Gty mmAx", 12),
                new Person("Jiop", 0),
                new Person("FfTy", 65),
                new Person("Trui", 43),
                new Person("asdd", 38),
                new Person("qwert", 1),
                new Person("vgyu", 56),
                new Person("vgyu", 120),
                new Person("Hew", 9)
            };

            Console.WriteLine(string.Join(Environment.NewLine, personsList));
            Console.WriteLine();

            var uniqueNamesList = personsList
                .Select(x => x.Name)
                .Distinct();
            Console.WriteLine("Names: " + string.Join(", ", uniqueNamesList) + ".");
            Console.WriteLine();

            var youngPeopleNamesList = personsList.Where(x => x.Age < 18)
                .Select(x => x.Name);
            var averageAgeOfYoung = personsList.Where(x => x.Age < 18)
                .Average(x => x.Age);
            Console.WriteLine("Names of young people: " + string.Join(", ", youngPeopleNamesList) + ".");
            Console.WriteLine($"Average age of them = {averageAgeOfYoung}");
            Console.WriteLine();

            var middleAgedPeopleList = personsList.Where(x => x.Age <= 45 && x.Age >= 20)
                .OrderByDescending(x => x.Age);
            Console.WriteLine("Middle aged people:");
            Console.WriteLine(string.Join(Environment.NewLine, middleAgedPeopleList));
            Console.WriteLine();

            var namesGroupDictionary = personsList
                .GroupBy(x => x.Name, x => x.Age)
                .ToDictionary(x => x.Key, x => x.Average());     
            Console.WriteLine("Grouped persons:");
            Console.WriteLine(string.Join(Environment.NewLine, namesGroupDictionary.Select(x => x.Key + ": " + x.Value.ToString())));

            Console.ReadLine();
        }
    }
}
