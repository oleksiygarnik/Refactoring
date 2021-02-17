using System.Collections.Generic;
using System.Linq;

namespace Refactoring.Complex
{
    public interface IPeopleCombinationService
    {
        PeopleCombination TakeFirstBySeniority(IEnumerable<PeopleCombination> combinations, SeniorityDiffCriterion sortCriterion);
    }

    public class PeopleCombinationService : IPeopleCombinationService
    {
        public PeopleCombination TakeFirstBySeniority(IEnumerable<PeopleCombination> combinations, SeniorityDiffCriterion sortCriterion)
        {
            var orderedCombinations = combinations.OrderByDescending(x => x.BirthDateDiff);

            return sortCriterion == SeniorityDiffCriterion.Minimum
                ? orderedCombinations.First()
                : orderedCombinations.Last();
        }
    }
}
