using System;
using System.Collections.Generic;
using System.Linq;

namespace Refactoring.Complex
{
    public class Finder
    {
        private readonly List<Person> _people;
        private readonly ICombinationFactory<PeopleCombination, Person> _combinationFactory;
        private readonly IPeopleCombinationService _combinationService;

        public Finder(
            List<Person> people,
            ICombinationFactory<PeopleCombination, Person> combinationFactory,
            IPeopleCombinationService combinationService)
        {
            if (people is null)
                throw new ArgumentNullException(nameof(people));

            if (combinationFactory is null)
                throw new ArgumentNullException(nameof(combinationFactory));

            if (combinationService is null)
                throw new ArgumentNullException(nameof(combinationService));

            _people = people;
            _combinationFactory = combinationFactory;
            _combinationService = combinationService;
        }

        public PeopleCombination FindByOrDefault(SeniorityDiffCriterion criterion)
        {
            var peopleCombinations = _combinationFactory.CreateCombinations(_people);

            if (!peopleCombinations.Any())
                return PeopleCombination.Empty;

            return _combinationService.TakeFirstBySeniority(peopleCombinations, criterion);
        }
    }
}
