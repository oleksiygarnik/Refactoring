using Refactoring.Simple;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Refactoring.Tests.Refactoring.Simple
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
    }
}
