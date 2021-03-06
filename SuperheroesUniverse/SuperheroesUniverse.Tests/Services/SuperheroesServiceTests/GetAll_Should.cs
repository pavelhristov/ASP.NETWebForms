﻿using Moq;
using NUnit.Framework;
using SuperheroesUniverse.Data;
using SuperheroesUniverse.Data.Models;
using SuperheroesUniverse.Services;
using SuperheroesUniverse.Tests.Helpers;
using System.Linq;

namespace SuperheroesUniverse.Tests.Services.SuperheroesServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void ReturnIQueriableOfSuperheroes_WhenCalled()
        {
            // Arrange
            var superheroes = Helper.GetSuperheroes();
            var contextMock = new Mock<ISuperheroesUniverseContext>();
            var superheroDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(superheroes);
            contextMock.Setup(ctx => ctx.Superheroes).Returns(superheroDbSetMock.Object);
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
            var superheroes = Helper.GetSuperheroes();
            var expectedResults = superheroes.Where(sh => !sh.isDeleted).AsQueryable();
            var contextMock = new Mock<ISuperheroesUniverseContext>();
            var superheroDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(superheroes);
            contextMock.Setup(ctx => ctx.Superheroes).Returns(superheroDbSetMock.Object);
            ISuperheroesService superheroesService = new SuperheroesService(contextMock.Object);

            // Act
            var superheroesFound = superheroesService.GetAll();

            // Assert
            CollectionAssert.AreEquivalent(expectedResults, superheroesFound);
        }
    }
}
