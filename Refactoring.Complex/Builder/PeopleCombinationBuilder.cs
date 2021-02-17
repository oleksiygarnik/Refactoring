using Refactoring.Complex.Requirements;

namespace Refactoring.Complex.Builder
{
    public class PeopleCombinationBuilder : BaseBuilder<PeopleCombination>
    {
        private readonly PeopleCombination _peopleCombination = PeopleCombination.Empty;

        private PeopleCombinationBuilder()
        {
        }

        public static PeopleCombinationBuilder Start() => new PeopleCombinationBuilder();

        public PeopleCombinationBuilder SetPeople(Person firstPerson, Person secondPerson)
        {
            if (firstPerson.IsYoungerThan(secondPerson))
                _peopleCombination.Set(firstPerson, secondPerson);
            else
                _peopleCombination.Set(secondPerson, firstPerson);

            return this;
        }

        public override ExecutionResult<PeopleCombination> Build()
        {
            var result = new ExecutionResult<PeopleCombination>(_peopleCombination);

            foreach (var requirement in _requirements)
            {
                if (!requirement.IsExecuted(_peopleCombination))
                    result.AddError(requirement.Error);
            }

            return result;
        }
    }
}
