using Moq;
using NUnit.Framework;
using SuperheroesUniverse.Data;
using SuperheroesUniverse.Data.Models;
using SuperheroesUniverse.Services;
using System;
using System.Data.Entity;

namespace SuperheroesUniverse.Tests.Services.SuperheroesServiceTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void ReturnNull_WhenIdIsNull()
        {
            // Arrange
            var contextMock = new Mock<ISuperheroesUniverseContext>();
            ISuperheroesService superheroesService = new SuperheroesService(contextMock.Object);

            // Act
            Superhero foudnSuperhero = superheroesService.GetById(null);

            // Assert
            Assert.IsNull(foudnSuperhero);
        }

        [Test]
        public void ReturnNull_WhenIdIsValidAndNoSuperheroIsFound()
        {
            // Arrange
            Superhero superhero = new Superhero()
            {
                Id = Guid.NewGuid(),
                Name = "name",
                SecretIdentity = "secret identity",
                ImgUrl = "image url",
                isDeleted = true
            };
            Guid anotherId = Guid.NewGuid();
            var contextMock = new Mock<ISuperheroesUniverseContext>();
            var superheroDbSetMock = new Mock<IDbSet<Superhero>>();
            contextMock.Setup(ctx => ctx.Superheroes).Returns(superheroDbSetMock.Object);
            superheroDbSetMock.Setup(sh => sh.Find(superhero.Id)).Returns((Superhero)null);
            ISuperheroesService superheroesService = new SuperheroesService(contextMock.Object);

            // Act
            Superhero foundSuperhero = superheroesService.GetById(superhero.Id);

            // Assert
            Assert.IsNull(foundSuperhero);
        }

        [Test]
        public void ReturnNull_WhenIdIsValidAndFoundSuperheroIsDeleted()
        {
            // Arrange
            Superhero superhero = new Superhero()
            {
                Id = Guid.NewGuid(),
                Name = "name",
                SecretIdentity = "secret identity",
                ImgUrl = "image url",
                isDeleted = true
            };
            var contextMock = new Mock<ISuperheroesUniverseContext>();
            var superheroDbSetMock = new Mock<IDbSet<Superhero>>();
            contextMock.Setup(ctx => ctx.Superheroes).Returns(superheroDbSetMock.Object);
            superheroDbSetMock.Setup(sh => sh.Find(superhero.Id)).Returns(superhero);
            ISuperheroesService superheroesService = new SuperheroesService(contextMock.Object);

            // Act
            Superhero foundSuperhero = superheroesService.GetById(superhero.Id);

            // Assert
            Assert.IsNull(foundSuperhero);
        }

        [Test]
        public void ReturnSuperhero_WhenIdIsValidAndFoundSuperheroIsNotDeleted()
        {
            // Arrange
            Superhero superhero = new Superhero()
            {
                Id = Guid.NewGuid(),
                Name = "name",
                SecretIdentity = "secret identity",
                ImgUrl = "image url",
                isDeleted = false
            };
            var contextMock = new Mock<ISuperheroesUniverseContext>();
            var superheroDbSetMock = new Mock<IDbSet<Superhero>>();
            contextMock.Setup(ctx => ctx.Superheroes).Returns(superheroDbSetMock.Object);
            superheroDbSetMock.Setup(sh => sh.Find(superhero.Id)).Returns(superhero);
            ISuperheroesService superheroesService = new SuperheroesService(contextMock.Object);

            // Act
            Superhero foundSuperhero = superheroesService.GetById(superhero.Id);

            // Assert
            Assert.AreSame(superhero, foundSuperhero);
        }
    }
}
