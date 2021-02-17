using Refactoring.Simple.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.Simple
{
    public class PeopleCombinationFactory : ICombinationFactory<PeopleCombination, Person>
    {
        public virtual List<PeopleCombination> CreateCombinations(List<Person> peoples)
        {
            var peopleCombinations = new List<PeopleCombination>();

            for (var i = 0; i < peoples.Count - 1; i++)
            {
                for (var j = i + 1; j < peoples.Count; j++)
                {
                    var firstPerson = peoples[i];
                    var secondPerson = peoples[j];

                    var combination = new PeopleCombination();

                    if (firstPerson.IsYoungerThan(secondPerson))
                        combination.Set(firstPerson, secondPerson);
                    else
                        combination.Set(secondPerson, firstPerson);

                    peopleCombinations.Add(combination);
                }
            }

            return peopleCombinations;
        }
    }
}
