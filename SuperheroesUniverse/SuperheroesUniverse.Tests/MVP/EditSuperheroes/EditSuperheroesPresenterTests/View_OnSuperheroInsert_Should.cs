using Moq;
using NUnit.Framework;
using SuperheroesUniverse.Data.Models;
using SuperheroesUniverse.MVP.EditSuperheroes;
using SuperheroesUniverse.Services;
using System;
using System.Web.ModelBinding;

namespace SuperheroesUniverse.Tests.MVP.EditSuperheroes.EditSuperheroesPresenterTests
{
    [TestFixture]
    public class View_OnSuperheroInsert_Should
    {
        [Test]
        public void CallTryUpdateModel_WhenInvoked()
        {
            // Arrange
            var viewMock = new Mock<IEditSuperheroesView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            var superheroesServiceMock = new Mock<ISuperheroesService>();

            EditSuperheroesPresenter superheroesPresenter = new EditSuperheroesPresenter(viewMock.Object, superheroesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnSuperheroInsert += null, new EventArgs());

            // Assert
            viewMock.Verify(v => v.TryUpdateModel(It.IsAny<Superhero>()), Times.Once());
        }

        [Test]
        public void CallInsertSuperhero_WhenModelStateIsValid()
        {
            // Arrange
            var viewMock = new Mock<IEditSuperheroesView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            
            var superheroesServiceMock = new Mock<ISuperheroesService>();

            EditSuperheroesPresenter superheroesPresenter = new EditSuperheroesPresenter(viewMock.Object, superheroesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnSuperheroInsert += null, new EventArgs());

            // Assert
            superheroesServiceMock.Verify(s => s.InsertSuperhero(It.IsAny<Superhero>()), Times.Once());

        }

        [Test]
        public void NotCallInsertSuperhero_WhenModelStateIsInvalid()
        {
            // Arrange
            var viewMock = new Mock<IEditSuperheroesView>();
            var modelStateMock = new ModelStateDictionary();
            modelStateMock.AddModelError("key", "error message");
            viewMock.Setup(v => v.ModelState).Returns(modelStateMock);

            var superheroesServiceMock = new Mock<ISuperheroesService>();

            EditSuperheroesPresenter superheroesPresenter = new EditSuperheroesPresenter(viewMock.Object, superheroesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnSuperheroInsert += null, new EventArgs());

            // Assert
            superheroesServiceMock.Verify(s => s.InsertSuperhero(It.IsAny<Superhero>()), Times.Never());

        }
    }
}
