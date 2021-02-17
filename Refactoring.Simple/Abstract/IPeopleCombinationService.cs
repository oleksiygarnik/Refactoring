using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.Simple.Abstract
{
    public interface IPeopleCombinationService
    {
        PeopleCombination TakeFirstBySeniority(IEnumerable<PeopleCombination> combinations, SeniorityDiffCriterion sortCriterion);
    }
}
