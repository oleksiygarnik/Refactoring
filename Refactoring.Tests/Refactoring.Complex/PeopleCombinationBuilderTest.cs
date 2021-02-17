using AutoFixture;
using Moq;
using Refactoring.Complex;
using Refactoring.Complex.Builder;
using Refactoring.Complex.Requirements;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Refactoring.Tests.Refactoring.Complex
{
    public class PeopleCombinationBuilderTest
    {
        private readonly Fixture _fixture;
        private List<Person> _people;

        public PeopleCombinationBuilderTest()
        {
            // create fixture
            _fixture = new Fixture();

            // set collection of people
            _people = Enumerable.Range(0, 10)
                .Select(x => _fixture.Create<Person>())
                .ToList();
        }

        [Fact]
        public void SetRequirements_GivenNull_Throws()
        {
            // Act
            var builder = PeopleCombinationBuilder.Start();

            // act
            var e = Assert.Throws<ArgumentNullException>(() => builder.SetRequirements(null));

            // Assert
            Assert.Equal("requirements", e.ParamName);
        }

        [Fact]
        public void SetRequirement_GivenNull_Throws()
        {
            // Act
            var builder = PeopleCombinationBuilder.Start();

            // act
            var e = Assert.Throws<ArgumentNullException>(() => builder.SetRequirement(null));

            // Assert
            Assert.Equal("requirement", e.ParamName);
        }

        [Fact]
        public void Build_WithOneRequirement_ReturnedSuccess()
        {
            // arrange
            var requirement = new Mock<IRequirement<PeopleCombination>>();

            requirement.Setup(x => x.IsExecuted(It.IsAny<PeopleCombination>()))
                .Returns(new ExecutionResult());

            // act
            var builderResult = PeopleCombinationBuilder
                       .Start()
                       .SetPeople(new Mock<Person>().Object, new Mock<Person>().Object)
                       .SetRequirement(requirement.Object)
                       .Build();

            // assert
            requirement.Verify(x => x.IsExecuted(It.IsAny<PeopleCombination>()), Times.Once);
            Assert.True(builderResult.Success);
        }

        [Fact]
        public void Build_WithCollectionOfRequirements_ReturnedSuccess()
        {
            // arrange
            var firstRequirement = new Mock<IRequirement<PeopleCombination>>();
            var secondRequirement = new Mock<IRequirement<PeopleCombination>>();

            firstRequirement.Setup(x => x.IsExecuted(It.IsAny<PeopleCombination>()))
              .Returns(new ExecutionResult());

            secondRequirement.Setup(x => x.IsExecuted(It.IsAny<PeopleCombination>()))
              .Returns(new ExecutionResult());

            // act
            var builderResult = PeopleCombinationBuilder
                       .Start()
                       .SetPeople(new Mock<Person>().Object, new Mock<Person>().Object)
                       .SetRequirements(new[] { firstRequirement.Object, secondRequirement.Object })
                       .Build();

            // assert
            firstRequirement.Verify(x => x.IsExecuted(It.IsAny<PeopleCombination>()), Times.Once);
            secondRequirement.Verify(x => x.IsExecuted(It.IsAny<PeopleCombination>()), Times.Once);
            Assert.True(builderResult.Success);
        }
        
        [Fact]
        public void Build_GivenFirstYoung_And_SecondOlderPeople_ReturnValidCombination()
        {
            // arrange 
            var firstPerson = new Mock<Person>();
            var secondPerson = new Mock<Person>();

            firstPerson.Setup(x => x.IsYoungerThan(secondPerson.Object))
                .Returns(true);

            // act
            var builderResult = PeopleCombinationBuilder
                .Start()
                .SetPeople(firstPerson.Object, secondPerson.Object)
                .Build();

            // assert
            firstPerson.Verify(x => x.IsYoungerThan(secondPerson.Object), Times.Once);

            Assert.Equal(firstPerson.Object.Name, builderResult.Value.FirstPerson.Name);
            Assert.Same(firstPerson.Object, builderResult.Value.FirstPerson);

            Assert.Equal(secondPerson.Object.Name, builderResult.Value.SecondPerson.Name);
            Assert.Same(secondPerson.Object, builderResult.Value.SecondPerson);
        }
    }
}
