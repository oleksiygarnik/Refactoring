using Refactoring.Complex.Builder;
using Refactoring.Complex.Requirements.PeopleCombinationRequirements;
using System.Collections.Generic;

namespace Refactoring.Complex
{
    public interface ICombinationFactory<TCombination, TValue> 
    {
        public List<TCombination> CreateCombinations(List<TValue> values);
    }

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

                    var builderResult = PeopleCombinationBuilder
                        .Start()
                        .SetPeople(firstPerson, secondPerson)
                        .SetRequirement(new FirstPersonIsYoungerThanSecond())
                        .Build();

                    if (builderResult.Success)
                        peopleCombinations.Add(builderResult.Value);
                }
            }

            return peopleCombinations;
        }
    }
}
