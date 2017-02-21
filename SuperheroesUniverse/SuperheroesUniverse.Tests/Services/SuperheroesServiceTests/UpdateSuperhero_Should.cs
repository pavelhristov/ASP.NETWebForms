using Moq;
using NUnit.Framework;
using SuperheroesUniverse.Data;
using SuperheroesUniverse.Data.Models;
using SuperheroesUniverse.Services;
using SuperheroesUniverse.Tests.Helpers;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace SuperheroesUniverse.Tests.Services.SuperheroesServiceTests
{
    [TestFixture]
    public class UpdateSuperhero_Should
    {
        [Test]
        public void ReturnNegative_WhenSuperheroDoesNotExist()
        {
            // Arrange
            var superheroes = Helper.GetSuperheroes();
            var contextMock = new Mock<ISuperheroesUniverseContext>();
            var superheroDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(superheroes);
            contextMock.Setup(ctx => ctx.Superheroes).Returns(superheroDbSetMock.Object);
            ISuperheroesService superheroesService = new SuperheroesService(contextMock.Object);

            // Act
            var result = superheroesService.UpdateSuperhero(new Superhero());

            // Assert
            Assert.IsTrue(result < 0);
        }

        // ASK FOR HELP!!!!!!!!!!!!
        //[Test]
        //public void ReturnPositive_WhenSuperheroIsUpdated()
        //{
        //    // Arrange
        //    var superheroes = Helper.GetSuperheroes();
        //    var contextMock = new Mock<ISuperheroesUniverseContext>();
        //    var superheroDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(superheroes);
        //    contextMock.Setup(ctx => ctx.Superheroes).Returns(superheroDbSetMock.Object);
        //    contextMock.Setup(ctx => ctx.SaveChanges()).Returns(1);
        //    contextMock.Setup(ctx => ctx.Entry(superheroes.ElementAt(0) as object)).Returns(It.IsAny<DbEntityEntry<Superhero>>());
        //    superheroDbSetMock.Setup(set => set.Find(superheroes.ElementAt(0).Id)).Returns(superheroes.ElementAt(0));
        //    var superheroesServiceMock = new Mock<SuperheroesService>(contextMock.Object);
        //    ISuperheroesService superheroesService = new SuperheroesService(contextMock.Object);

        //    // Act
        //    var result = superheroesService.UpdateSuperhero(superheroes.ElementAt(0));

        //    // Assert
        //    Assert.IsTrue(result > 0);
        //}
    }
}
