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
    public class View_OnSuperheroUpdate_Should
    {
        [Test]
        public void AddModelError_WhenSuperheroIsNotFound()
        {
            // Arrange
            var viewMock = new Mock<IEditSuperheroesView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            Guid id = Guid.NewGuid();
            //string expectedError = string.Format("Item with id {0} was not found", id);
            string errorKey = "";

            var superheroesServiceMock = new Mock<ISuperheroesService>();
            superheroesServiceMock.Setup(s => s.GetById(id)).Returns((Superhero)null);

            EditSuperheroesPresenter superheroesPresenter = new EditSuperheroesPresenter(viewMock.Object, superheroesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnSuperheroUpdate += null, new EditSuperheroesIdEventArgs(id));

            // Assert
            Assert.AreEqual(1, viewMock.Object.ModelState[errorKey].Errors.Count);
            //StringAssert.AreEqualIgnoringCase(expectedError, viewMock.Object.ModelState[errorKey].Errors[0].ErrorMessage);
            StringAssert.Contains(id.ToString(), viewMock.Object.ModelState[errorKey].Errors[0].ErrorMessage);
        }

        [Test]
        public void NotCallTryUpdateModel_WhenSuperheroIsNotFound()
        {
            // Arrange
            var viewMock = new Mock<IEditSuperheroesView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            Guid id = Guid.NewGuid();

            var superheroesServiceMock = new Mock<ISuperheroesService>();
            superheroesServiceMock.Setup(s => s.GetById(id)).Returns((Superhero)null);

            EditSuperheroesPresenter superheroesPresenter = new EditSuperheroesPresenter(viewMock.Object, superheroesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnSuperheroUpdate += null, new EditSuperheroesIdEventArgs(id));

            // Assert
            viewMock.Verify(v => v.TryUpdateModel(It.IsAny<Superhero>()), Times.Never());
        }

        [Test]
        public void CallTryUpdateModel_WhenSuperheroIsFound()
        {
            // Arrange
            var viewMock = new Mock<IEditSuperheroesView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            Guid id = Guid.NewGuid();

            var superheroesServiceMock = new Mock<ISuperheroesService>();
            superheroesServiceMock.Setup(s => s.GetById(id)).Returns(new Superhero() { Id = id });

            EditSuperheroesPresenter superheroesPresenter = new EditSuperheroesPresenter(viewMock.Object, superheroesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnSuperheroUpdate += null, new EditSuperheroesIdEventArgs(id));

            // Assert
            viewMock.Verify(v => v.TryUpdateModel(It.IsAny<Superhero>()), Times.Once());
        }

        [Test]
        public void CallUpdateSuperhero_WhenSuperheroIsFoundAndIsInValidState()
        {
            // Arrange
            var viewMock = new Mock<IEditSuperheroesView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            Guid id = Guid.NewGuid();
            var superheroToUpdate = new Superhero()
            {
                Id = id,
                Name = "name",
                SecretIdentity = "secret identity",
                ImgUrl = "url",
                isDeleted = false
            };

            var superheroesServiceMock = new Mock<ISuperheroesService>();
            superheroesServiceMock.Setup(s => s.GetById(id)).Returns(superheroToUpdate);

            EditSuperheroesPresenter superheroesPresenter = new EditSuperheroesPresenter(viewMock.Object, superheroesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnSuperheroUpdate += null, new EditSuperheroesIdEventArgs(id));

            // Assert
            superheroesServiceMock.Verify(s => s.UpdateSuperhero(superheroToUpdate), Times.Once());
        }

        [Test]
        public void UpdateSuperheroIsNotCalled_WhenSuperheroIsFoundAndIsInInvalidState()
        {
            // Arrange
            var viewMock = new Mock<IEditSuperheroesView>();
            var modelStateMock = new ModelStateDictionary();
            modelStateMock.AddModelError("key", "error message");
            viewMock.Setup(v => v.ModelState).Returns(modelStateMock);

            Guid id = Guid.NewGuid();
            var superheroToUpdate = new Superhero()
            {
                Id = id,
                Name = "name",
                SecretIdentity = "secret identity",
                ImgUrl = "url",
                isDeleted = false
            };

            var superheroesServiceMock = new Mock<ISuperheroesService>();
            superheroesServiceMock.Setup(s => s.GetById(id)).Returns(superheroToUpdate);

            EditSuperheroesPresenter superheroesPresenter = new EditSuperheroesPresenter(viewMock.Object, superheroesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnSuperheroUpdate += null, new EditSuperheroesIdEventArgs(id));

            // Assert
            superheroesServiceMock.Verify(s => s.UpdateSuperhero(superheroToUpdate), Times.Never());
        }
    }
}
