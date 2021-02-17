using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.Complex.Requirements.PeopleCombinationRequirements
{
    public class FirstPersonIsYoungerThanSecond : IRequirement<PeopleCombination>
    {
        public ErrorInfo Error => 
            new ErrorInfo("First person should be younger than second");

        public virtual ExecutionResult IsExecuted(PeopleCombination peopleCombination)
        {
            var result = new ExecutionResult();

            if (peopleCombination.FirstPerson is null || peopleCombination.SecondPerson is null)
                result.AddError(new ErrorInfo("People combination is not valid model!"));

            if (!peopleCombination.FirstPerson.IsYoungerThan(peopleCombination.SecondPerson))
                result.AddError(Error);

            return result;
        }
    }
}
