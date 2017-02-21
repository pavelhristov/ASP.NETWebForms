using Moq;
using NUnit.Framework;
using SuperheroesUniverse.Data;
using SuperheroesUniverse.Data.Models;
using SuperheroesUniverse.Services;
using SuperheroesUniverse.Tests.Helpers;
using System;

namespace SuperheroesUniverse.Tests.Services.SuperheroesServiceTests
{
    [TestFixture]
    public class RestoreSuperhero_Should
    {
        [Test]
        public void ReturnPositive_WhenSuperheroIsFoundAndRestored()
        {
            // Arrange
            Superhero superhero = new Superhero
            {
                Id = Guid.NewGuid(),
                Name = "name",
                SecretIdentity = "secret identity",
                ImgUrl = "url",
                isDeleted = true
            };
            var superheroes = Helper.GetSuperheroes();
            var contextMock = new Mock<ISuperheroesUniverseContext>();
            var superheroDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(superheroes);
            contextMock.Setup(ctx => ctx.Superheroes).Returns(superheroDbSetMock.Object);
            contextMock.Setup(ctx => ctx.SaveChanges()).Returns(1);
            superheroDbSetMock.Setup(sh => sh.Find(superhero.Id)).Returns(superhero);
            ISuperheroesService superheroesService = new SuperheroesService(contextMock.Object);

            // Act
            var result = superheroesService.RestoreSuperhero(superhero.Id);

            // Assert
            Assert.IsTrue(result > 0);
        }

        [Test]
        public void Throw_WhenSuperheroIsNotFound()
        {
            // Arrange
            Superhero superhero = new Superhero
            {
                Id = Guid.NewGuid(),
                Name = "name",
                SecretIdentity = "secret identity",
                ImgUrl = "url",
                isDeleted = true
            };
            var superheroes = Helper.GetSuperheroes();
            var contextMock = new Mock<ISuperheroesUniverseContext>();
            var superheroDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(superheroes);
            contextMock.Setup(ctx => ctx.Superheroes).Returns(superheroDbSetMock.Object);
            superheroDbSetMock.Setup(sh => sh.Find(superhero.Id)).Returns((Superhero)null);
            ISuperheroesService superheroesService = new SuperheroesService(contextMock.Object);

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => superheroesService.RestoreSuperhero(superhero.Id));

            // Assert
            Assert.That(ex.Message, Is.EqualTo("The argument is null.\r\nParameter name: superhero"));
        }

        [Test]
        public void Throw_WhenIdIsNull()
        {
            // Arrange
            var superheroes = Helper.GetSuperheroes();
            var contextMock = new Mock<ISuperheroesUniverseContext>();
            var superheroDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(superheroes);
            contextMock.Setup(ctx => ctx.Superheroes).Returns(superheroDbSetMock.Object);
            contextMock.Setup(ctx => ctx.SaveChanges()).Returns(1);
            superheroDbSetMock.Setup(sh => sh.Find(null)).Returns((Superhero)null);
            ISuperheroesService superheroesService = new SuperheroesService(contextMock.Object);

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => superheroesService.RestoreSuperhero(Guid.NewGuid()));

            // Assert
            Assert.That(ex.Message, Is.EqualTo("The argument is null.\r\nParameter name: superhero"));
        }

        [Test]
        public void ChangeSuperheroIsDeletedToFalse_WhenSuperheroIsFoundAndRestored()
        {
            // Arrange
            Superhero superhero = new Superhero
            {
                Id = Guid.NewGuid(),
                Name = "name",
                SecretIdentity = "secret identity",
                ImgUrl = "url",
                isDeleted = true
            };
            var superheroes = Helper.GetSuperheroes();
            var contextMock = new Mock<ISuperheroesUniverseContext>();
            var superheroDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(superheroes);
            contextMock.Setup(ctx => ctx.Superheroes).Returns(superheroDbSetMock.Object);
            contextMock.Setup(ctx => ctx.SaveChanges()).Returns(1);
            superheroDbSetMock.Setup(sh => sh.Find(superhero.Id)).Returns(superhero);
            ISuperheroesService superheroesService = new SuperheroesService(contextMock.Object);

            // Act
            superheroesService.RestoreSuperhero(superhero.Id);

            // Assert
            Assert.IsFalse(superhero.isDeleted);
        }
    }
}
