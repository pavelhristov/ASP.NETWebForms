using Moq;
using NUnit.Framework;
using SuperheroesUniverse.Data;
using SuperheroesUniverse.Data.Models;
using SuperheroesUniverse.Services;
using SuperheroesUniverse.Tests.Helpers;
using System;
using System.Linq;

namespace SuperheroesUniverse.Tests.Services.SuperheroesServiceTests
{
    [TestFixture]
    public class InsertSuperhero_Should
    {
        [Test]
        public void ReturnPositive_WhenSuperheroIsAddedSuccessful()
        {
            // Arrange
            Superhero superhero = new Superhero
            {
                Id = Guid.NewGuid(),
                Name = "name",
                SecretIdentity = "secret identity",
                ImgUrl = "url",
                isDeleted = false
            };
            var superheroes = Helper.GetSuperheroes();
            var contextMock = new Mock<ISuperheroesUniverseContext>();
            var superheroDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(superheroes);
            contextMock.Setup(ctx => ctx.Superheroes).Returns(superheroDbSetMock.Object);
            contextMock.Setup(ctx => ctx.SaveChanges()).Returns(1);
            superheroDbSetMock.Setup(sh => sh.Add(superhero)).Returns(superhero);
            ISuperheroesService superheroesService = new SuperheroesService(contextMock.Object);

            // Act
            var result = superheroesService.InsertSuperhero(superhero);

            // Assert
            Assert.IsTrue(result > 0);
        }

        [Test]
        public void UpdateTheCollection_WhenSuperheroIsAddedSuccessful()
        {
            // Arrange
            Superhero superhero = new Superhero
            {
                Id = Guid.NewGuid(),
                Name = "name",
                SecretIdentity = "secret identity",
                ImgUrl = "url",
                isDeleted = false
            };
            var superheroes = Helper.GetSuperheroes().ToList();
            var contextMock = new Mock<ISuperheroesUniverseContext>();
            var superheroDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(superheroes.AsEnumerable());
            contextMock.Setup(ctx => ctx.Superheroes).Returns(superheroDbSetMock.Object);
            contextMock.Setup(ctx => ctx.SaveChanges()).Returns(1);
            superheroDbSetMock.Setup(sh => sh.Add(superhero)).Returns(() => { superheroes.Add(superhero); return superhero; });
            ISuperheroesService superheroesService = new SuperheroesService(contextMock.Object);

            // Act
            superheroesService.InsertSuperhero(superhero);

            // Assert
            Assert.IsTrue(superheroes.Contains(superhero));
        }
    }
}
