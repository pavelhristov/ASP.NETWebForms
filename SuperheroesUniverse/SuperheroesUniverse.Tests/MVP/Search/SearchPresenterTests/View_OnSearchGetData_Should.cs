using Moq;
using NUnit.Framework;
using SuperheroesUniverse.MVP.Search;
using SuperheroesUniverse.Services;
using SuperheroesUniverse.Tests.Helpers;
using System.Linq;

namespace SuperheroesUniverse.Tests.MVP.Search.SearchPresenterTests
{
    [TestFixture]
    public class View_OnSearchGetData_Should
    {
        [Test]
        [TestCase("3")]
        [TestCase("name 3")]
        [TestCase("")]
        [TestCase("url")]
        public void AddSuperheroToViewModel_WhenOnSearchGetDataIsRaised(string pattern)
        {
            // Arrange
            var superheroes = Helper.GetSuperheroes();
            var viewMock = new Mock<ISearchView>();
            var expectedResults = superheroes.Where(sh => (sh.SecretIdentity.Contains(pattern) || sh.Name.Contains(pattern)) && !sh.isDeleted).AsQueryable();
            viewMock.Setup(v => v.Model).Returns(new SearchViewModel());
            var superheroesServiceMock = new Mock<ISuperheroesService>();
            superheroesServiceMock.Setup(s => s.Search(pattern)).Returns(expectedResults);

            SearchPresenter superheroesPresenter = new SearchPresenter(viewMock.Object, superheroesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnSearchGetData += null, new SearchGetDataEventArgs(pattern));

            // Assert
            CollectionAssert.AreEquivalent(expectedResults, viewMock.Object.Model.Superheroes);
        }

        [Test]
        [TestCase("whatever")]
        [TestCase("")]
        public void CallSearchWithProperParameters_WhenRaised(string pattern)
        {
            // Arrange
            var superheroes = Helper.GetSuperheroes();
            var viewMock = new Mock<ISearchView>();
            var expectedResults = superheroes.Where(sh => (sh.SecretIdentity.Contains(pattern) || sh.Name.Contains(pattern)) && !sh.isDeleted).AsQueryable();
            viewMock.Setup(v => v.Model).Returns(new SearchViewModel());
            var superheroesServiceMock = new Mock<ISuperheroesService>();
            superheroesServiceMock.Setup(s => s.Search(pattern)).Returns(expectedResults);

            SearchPresenter superheroesPresenter = new SearchPresenter(viewMock.Object, superheroesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnSearchGetData += null, new SearchGetDataEventArgs(pattern));

            // Assert
            superheroesServiceMock.Verify(s => s.Search(pattern), Times.Once());
        }
    }
}
