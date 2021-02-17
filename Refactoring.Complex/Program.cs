using System;
using System.Collections.Generic;

namespace Refactoring.Execute
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var n = 365;
            var result = n;
            while(n != 1)
            {
                n--;
                result += n;
            }
            Console.WriteLine(n);
            //var person1 = new Person("Oleksii Harnyk", new DateTime(1999, 7, 27));
            //var person2 = new Person("Maksim Korobenko", new DateTime(1999, 4, 27));
            //var person3 = new Person("Vlad Nabok", new DateTime(1999, 11, 27));

            //var people = new List<Person>
            //{
            //    person1,
            //    person2,
            //    person3
            //};

            //var finder = new Finder(people);

            //var peopleCombination = finder.FindBySeniorityDiff(SeniorityDiffCriterion.Maximum);

            //Console.WriteLine(peopleCombination);
        }
    }
}
