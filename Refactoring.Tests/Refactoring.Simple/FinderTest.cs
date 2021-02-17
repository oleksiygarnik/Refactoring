using AutoFixture;
using Moq;
using Refactoring.Simple;
using Refactoring.Simple.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Refactoring.Tests.Refactoring.Simple
{
    public class FinderTest
    {
        private readonly Fixture _fixture;
        private readonly Mock<ICombinationFactory<PeopleCombination, Person>> _combinationFactory;
        private readonly Mock<IPeopleCombinationService> _combinationService;
        private List<Person> _people;
        public FinderTest()
        {
            // create fixture
            _fixture = new Fixture();

            // set collection of people
            _people = Enumerable.Range(0, 5)
                .Select(x => _fixture.Create<Person>())
                .ToList();

            _combinationFactory = new Mock<ICombinationFactory<PeopleCombination, Person>>();
            _combinationService = new Mock<IPeopleCombinationService>();
        }

        [Fact]
        public void Ctor_GivenPeople_IsNull_Throws()
        {
            //act
            var e = Assert.Throws<ArgumentNullException>(() => new Finder(null, _combinationFactory.Object, _combinationService.Object));

            // assert
            Assert.Equal("people", e.ParamName);
        }

        [Fact]
        public void Ctor_GivenFactory_IsNull_Throws()
        {
            //act
            var e = Assert.Throws<ArgumentNullException>(() => new Finder(_people, null, _combinationService.Object));

            // assert
            Assert.Equal("combinationFactory", e.ParamName);
        }

        [Fact]
        public void Ctor_GivenService_IsNull_Throws()
        {
            //act
            var e = Assert.Throws<ArgumentNullException>(() => new Finder(_people, _combinationFactory.Object, null));

            // assert
            Assert.Equal("combinationService", e.ParamName);
        }

        [Fact]
        public void Find_GivenPeopleCollection_IsEmpty_ReturnedEmptyObject()
        {
            //arrange

            _combinationFactory.Setup(x => x.CreateCombinations(_people))
              .Returns(new List<PeopleCombination>());

            // act
            var finder = new Finder(_people, _combinationFactory.Object, _combinationService.Object);
            var actual = finder.FindByOrDefault(SeniorityDiffCriterion.Maximum);

            // assert
            _combinationFactory.Verify(x => x.CreateCombinations(It.IsAny<List<Person>>()), Times.Once);
            Assert.Null(actual.FirstPerson);
            Assert.Null(actual.SecondPerson);
            Assert.Equal(default, actual.BirthDateDiff);
        }

        [Fact]
        public void Hello()
        {
            // arrange 
            var combinations = new Mock<List<PeopleCombination>>(
                Enumerable.Range(0, 10)
                .Select(x => _fixture.Create<PeopleCombination>())
                .ToList());

            var peopleCombination = new Mock<PeopleCombination>();

            _combinationFactory.Setup(x => x.CreateCombinations(_people))
              .Returns(combinations.Object);

            _combinationService.Setup(x => x.TakeFirstBySeniority(combinations.Object, It.IsAny<SeniorityDiffCriterion>()))
                .Returns(new PeopleCombination());

            // act
            var finder = new Finder(_people, _combinationFactory.Object, _combinationService.Object);

            var actual = finder.FindByOrDefault(SeniorityDiffCriterion.Maximum);

            // assert
            _combinationFactory.Verify(x => x.CreateCombinations(It.IsAny<List<Person>>()), Times.Once);
            _combinationService.Verify(x => x.TakeFirstBySeniority(It.IsAny<List<PeopleCombination>>(), It.IsAny<SeniorityDiffCriterion>()), Times.Once);
            Assert.NotNull(actual);
        }
    }
}
