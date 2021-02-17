using AutoFixture;
using Refactoring.Complex;
using System;
using Xunit;

namespace Refactoring.Tests.Refactoring.Complex
{
    public class PeopleCombinationTest
    {
        private readonly Fixture _fixture;
        private Person _firstPerson;
        private Person _secondPerson;
        private Person _thirdPerson;

        public PeopleCombinationTest()
        {
            _fixture = new Fixture();
            _firstPerson = new Person("Oleksii", new DateTime(1999, 7, 27));
            _secondPerson = new Person("Igor", new DateTime(1985, 10, 10));
            _thirdPerson = new Person("Olga", new DateTime(1999, 7, 26));
        }

        [Fact]
        public void Ctor_GivenFirstPerson_IsNull_Throws()
        {
            Assert.Throws<ArgumentNullException>(
                "firstPerson",
                () => new PeopleCombination(null, _secondPerson, _fixture.Create<TimeSpan>()));
        }

        [Fact]
        public void Ctor_GivenSecondPerson_IsNull_Throws()
        {
            Assert.Throws<ArgumentNullException>(
                "secondPerson",
                () => new PeopleCombination(_firstPerson, null, _fixture.Create<TimeSpan>()));
        }

        [Fact]
        public void Set_GivenTwoPersons_ReturnPeopleCombinationEntity()
        {
            // arrange
            var actual = PeopleCombination.Empty;
            var birthDateDiff = _firstPerson.BirthDate - _thirdPerson.BirthDate;
            var expected = new PeopleCombination(_thirdPerson, _firstPerson, birthDateDiff);

            // act
            actual.Set(_thirdPerson, _firstPerson);

            // Assert
            Assert.Equal(expected.ToString(), actual.ToString());
        }

        [Fact]
        public void Default_IfEmpty_Return_EmptyPeopleCombination()
        {
            // act
            var actual = PeopleCombination.Empty;

            // assert 
            Assert.Null(actual.FirstPerson);
            Assert.Null(actual.SecondPerson);
            Assert.Equal(default, actual.BirthDateDiff);
        }
    }
}
