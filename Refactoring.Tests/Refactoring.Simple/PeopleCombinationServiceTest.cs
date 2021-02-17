using AutoFixture;
using Refactoring.Simple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Refactoring.Tests.Refactoring.Simple
{
    public class PeopleCombinationServiceTest
    {
        private static PeopleCombination _firstCombination;
        private static PeopleCombination _secondCombination;
        private static PeopleCombination _thirdCombination;

        public PeopleCombinationServiceTest()
        {
            var firstPerson = new Person("Oleksii", new DateTime(1999, 7, 27));
            var secondPerson = new Person("Igor", new DateTime(1985, 12, 12));
            var thirdPerson = new Person("Olga", new DateTime(2000, 7, 27));

            _firstCombination = new PeopleCombination
            {
                FirstPerson = firstPerson,
                SecondPerson = secondPerson,
                BirthDateDiff = secondPerson.BirthDate - firstPerson.BirthDate,
            };

            _secondCombination = new PeopleCombination
            {
                FirstPerson = thirdPerson,
                SecondPerson = firstPerson,
                BirthDateDiff = firstPerson.BirthDate - thirdPerson.BirthDate,
            };

            _thirdCombination = new PeopleCombination
            {
                FirstPerson = thirdPerson,
                SecondPerson = secondPerson,
                BirthDateDiff = secondPerson.BirthDate - thirdPerson.BirthDate,
            };
        }

        [Fact]
        public void Take_GiveCombinations_ReturnMinimumSenioriyDiff()
        {
            // arrange 
            var combinations = new List<PeopleCombination> { _firstCombination, _secondCombination, _thirdCombination };
            var expected = _secondCombination;

            // act
            var service = new PeopleCombinationService();
            var actual = service.TakeFirstBySeniority(combinations, SeniorityDiffCriterion.Minimum);

            // assert
            Assert.Equal(expected, actual);
            Assert.Same(expected, actual);
        }

        [Fact]
        public void Take_GiveCombinations_ReturnMaximumSenioriyDiff()
        {
            // arrange 
            var combinations = new List<PeopleCombination> { _firstCombination, _secondCombination, _thirdCombination };
            var expected = _thirdCombination;

            // act
            var service = new PeopleCombinationService();
            var actual = service.TakeFirstBySeniority(combinations, SeniorityDiffCriterion.Maximum);

            // assert
            Assert.Equal(expected, actual);
            Assert.Same(expected, actual);
        }
    }
}
