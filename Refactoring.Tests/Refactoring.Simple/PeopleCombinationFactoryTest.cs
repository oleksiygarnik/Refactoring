using AutoFixture;
using Moq;
using Refactoring.Simple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Refactoring.Tests.Refactoring.Simple
{
    public class PeopleCombinationFactoryTest
    {
        private readonly Fixture _fixture;
        private List<Person> _people;
        public PeopleCombinationFactoryTest()
        {
            // create fixture
            _fixture = new Fixture();

            // set collection of people
            _people = Enumerable.Range(0, 5)
                .Select(x => _fixture.Create<Person>())
                .ToList();
        }

        [Fact]
        public void GetCombinations_IfPeopleCollectionSize5_ThenReturn10Combinations()
        {
            // arrange
            int expected = 10;

            // act
            var factory = new PeopleCombinationFactory();
            var actual = factory.CreateCombinations(_people);

            // assert
            Assert.Equal(expected, actual.Count());
        }
    }
}
