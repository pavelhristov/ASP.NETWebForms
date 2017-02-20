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
    public class GetAll_Should
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
            var superheroes = this.GetSuperheroes();
            var contextMock = new Mock<ISuperheroesUniverseContext>();
            var superheroDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(superheroes);
            contextMock.Setup(ctx => ctx.Superheroes).Returns(superheroDbSetMock);
            ISuperheroesService superheroesService = new SuperheroesService(contextMock.Object);

            // Act
            var superheroesFound = superheroesService.GetAll();

            // Assert
            Assert.IsInstanceOf<IQueryable<Superhero>>(superheroesFound);
        }

        [Test]
        public void NotReturnSuperheroes_WhoAreDeleted()
        {
            // Arrange
            var superheroes = this.GetSuperheroes();
            var expectedResults = superheroes.Where(sh => !sh.isDeleted).AsQueryable();
            var contextMock = new Mock<ISuperheroesUniverseContext>();
            var superheroDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(superheroes);
            contextMock.Setup(ctx => ctx.Superheroes).Returns(superheroDbSetMock);
            ISuperheroesService superheroesService = new SuperheroesService(contextMock.Object);

            // Act
            var superheroesFound = superheroesService.GetAll();

            // Assert
            CollectionAssert.AreEquivalent(expectedResults, superheroesFound);
        }
    }
}
