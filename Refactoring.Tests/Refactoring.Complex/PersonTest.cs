using Refactoring.Complex;
using Refactoring.Execute;
using System;
using Xunit;

namespace Refactoring.Tests.Refactoring.Complex
{
    public class PersonTest
    {
        private Person _firstPerson;
        private Person _secondPerson;

        public PersonTest()
        {
            _firstPerson = new Person("Oleksii", new DateTime(1999, 7, 27));
            _secondPerson = new Person("Igor", new DateTime(1985, 12, 12));
        }

        [Theory]
        [InlineData("Oleksiy", "1999-7-27")]
        [InlineData("Ivan", "1999-4-20")]
        [InlineData("Andriy", "1986-10-10")]
        public void Ctor(string name, string birthDate)
        {
            // Arrange
            var expectedBirthDate = DateTime.Parse(birthDate);

            // Act
            var person = new Person(name, expectedBirthDate);

            // Assert
            Assert.Equal(person.Name, name);
            Assert.Equal(person.BirthDate, expectedBirthDate);
        }

        [Theory]
        [InlineData("", "1999-7-27")]
        public void Ctor_GivenEmptyName_Throws(string name, string birthDate)
        {
            // Arrange
            var expectedBirthDate = DateTime.Parse(birthDate);

            // Act
            var e = Assert.Throws<ArgumentNullException>(() => new Person(name, expectedBirthDate));

            // Assert
            Assert.Equal(nameof(name), e.ParamName);
        }

        [Fact]
        public void Check_IfGivenPerson_IsYounger_ReturnFalse()
        {
            // Act 
            var result = _secondPerson.IsYoungerThan(_firstPerson);

            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("Alex")]
        public void ChangeName_IfGivenNewName_ReturnPersonWithNewName(string newName)
        {
            // Act
            _firstPerson.ChangeName(newName);

            // Assert
            Assert.Equal(_firstPerson.Name, newName);
        }

        [Fact]
        public void ChangeName_GivenName_IsNull_Throws()
        {
            Assert.Throws<ArgumentNullException>("name", () => _firstPerson.ChangeName(null));
        }
    }
}
