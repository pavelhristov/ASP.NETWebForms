using Moq;
using NUnit.Framework;
using SuperheroesUniverse.MVP.Superheroes;
using SuperheroesUniverse.Services;
using SuperheroesUniverse.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroesUniverse.Tests.MVP.Superheroes.SuperheroesPresenterTests
{
    [TestFixture]
    public class View_OnSuperheroesGetData_Should
    {
        [Test]
        public void AddSuperheroesToViewModel_WhenOnSuperheroesGetDataIsRaised()
        {
            // Arrange
            var superheroes = Helper.GetSuperheroes().AsQueryable();
            var viewMock = new Mock<ISuperheroesView>();
            viewMock.Setup(v => v.Model).Returns(new SuperheroesViewModel());
            var superheroesServiceMock = new Mock<ISuperheroesService>();
            superheroesServiceMock.Setup(s => s.GetAll()).Returns(superheroes);

            SuperheroesPresenter superheroesPresenter = new SuperheroesPresenter(viewMock.Object, superheroesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnSuperheroesGetData += null, EventArgs.Empty);

            // Assert
            CollectionAssert.AreEquivalent(superheroes, viewMock.Object.Model.Superheroes);
        }
    }
}
