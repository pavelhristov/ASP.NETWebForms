using Moq;
using NUnit.Framework;
using SuperheroesUniverse.Data;
using SuperheroesUniverse.Data.Models;
using SuperheroesUniverse.Services;
using SuperheroesUniverse.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperheroesUniverse.Tests.Services.SuperheroesServiceTests
{
    [TestFixture]
    public class Search_Should
    {
        private IEnumerable<Superhero> GetSuperheroes()
        {
            return new List<Superhero>()
            {
                new Superhero()
                {
                    Id = Guid.NewGuid(),
                    Name = "name 1",
                    SecretIdentity = "secret identity 1",
                    ImgUrl = "image url 1",
                    isDeleted = false
                },new Superhero()
                {
                    Id = Guid.NewGuid(),
                    Name = "name 2",
                    SecretIdentity = "secret identity 2",
                    ImgUrl = "image url 2",
                    isDeleted = false
                },new Superhero()
                {
                    Id = Guid.NewGuid(),
                    Name = "name 3",
                    SecretIdentity = "secret identity 3",
                    ImgUrl = "image url 3",
                    isDeleted = true
                }
            };
        }

        [Test]
        public void ReturnIQueriableOfSuperheroes_WhenCalled()
        {
            // Arrange
            var contextMock = new Mock<ISuperheroesUniverseContext>();
            var superheroDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(this.GetSuperheroes());
            contextMock.Setup(ctx => ctx.Superheroes).Returns(superheroDbSetMock);
            ISuperheroesService superheroesService = new SuperheroesService(contextMock.Object);
            string pattern = "some pattern";

            // Act
            var superheroesFound = superheroesService.Search(pattern);

            // Assert
            Assert.IsInstanceOf<IQueryable<Superhero>>(superheroesFound);
        }

        [Test]
        [TestCase("name")]
        [TestCase("2")]
        [TestCase("url")]
        public void ReturnSuperheroes_WhoAreNotDeletedAndMatchingPatternForName(string patternForName)
        {
            // Arrange
            var superheroes = this.GetSuperheroes();
            var expectedResults = superheroes.Where(sh => sh.Name.Contains(patternForName) && !sh.isDeleted).AsQueryable();
            var contextMock = new Mock<ISuperheroesUniverseContext>();
            var superheroDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(superheroes);
            contextMock.Setup(ctx => ctx.Superheroes).Returns(superheroDbSetMock);
            ISuperheroesService superheroesService = new SuperheroesService(contextMock.Object);

            // Act
            var superheroesFound = superheroesService.Search(patternForName);

            // Assert
            CollectionAssert.AreEquivalent(expectedResults, superheroesFound);
        }

        [Test]
        [TestCase("secret")]
        [TestCase("1")]
        [TestCase("identity")]
        [TestCase("url")]
        public void ReturnSuperheroes_WhoAreNotDeletedAndMatchingPatternForSecretIdentity(string patternForSecretIdentity)
        {
            // Arrange
            var superheroes = this.GetSuperheroes();
            var expectedResults = superheroes.Where(sh => sh.SecretIdentity.Contains(patternForSecretIdentity) && !sh.isDeleted).AsQueryable();
            var contextMock = new Mock<ISuperheroesUniverseContext>();
            var superheroDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(superheroes);
            contextMock.Setup(ctx => ctx.Superheroes).Returns(superheroDbSetMock);
            ISuperheroesService superheroesService = new SuperheroesService(contextMock.Object);

            // Act
            var superheroesFound = superheroesService.Search(patternForSecretIdentity);

            // Assert
            CollectionAssert.AreEquivalent(expectedResults, superheroesFound);
        }

        [Test]
        [TestCase("3")]
        [TestCase("name 3")]
        [TestCase("")]
        [TestCase("url")]
        public void NotReturnSuperheroes_WhoAreDeletedAndMatchingPatternForName(string pattern)
        {
            // Arrange
            var superheroes = this.GetSuperheroes();
            var expectedResults = superheroes.Where(sh => (sh.SecretIdentity.Contains(pattern)|| sh.Name.Contains(pattern)) && !sh.isDeleted).AsQueryable();
            var contextMock = new Mock<ISuperheroesUniverseContext>();
            var superheroDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(superheroes);
            contextMock.Setup(ctx => ctx.Superheroes).Returns(superheroDbSetMock);
            ISuperheroesService superheroesService = new SuperheroesService(contextMock.Object);

            // Act
            var superheroesFound = superheroesService.Search(pattern);

            // Assert
            CollectionAssert.AreEquivalent(expectedResults, superheroesFound);
        }
    }
}
