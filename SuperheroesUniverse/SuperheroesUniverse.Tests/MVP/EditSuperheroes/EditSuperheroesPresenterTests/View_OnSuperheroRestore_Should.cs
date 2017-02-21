using Moq;
using NUnit.Framework;
using SuperheroesUniverse.MVP.EditSuperheroes;
using SuperheroesUniverse.Services;
using System;

namespace SuperheroesUniverse.Tests.MVP.EditSuperheroes.EditSuperheroesPresenterTests
{
    [TestFixture]
    public class View_OnSuperheroRestore_Should
    {
        [Test]
        public void CallRestoreSuperhero_WhenInvoked()
        {
            // Arrange
            var viewMock = new Mock<IEditSuperheroesView>();

            Guid id = Guid.NewGuid();

            var superheroesServiceMock = new Mock<ISuperheroesService>();
            superheroesServiceMock.Setup(s => s.RestoreSuperhero(id)).Returns(1);

            EditSuperheroesPresenter superheroesPresenter = new EditSuperheroesPresenter(viewMock.Object, superheroesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnSuperheroRestore += null, new EditSuperheroesIdEventArgs(id));

            // Assert
            superheroesServiceMock.Verify(s => s.RestoreSuperhero(It.IsAny<Guid>()), Times.Once());
        }
        
        [Test]
        public void CallRestoreSuperhero_WithRightParameters_WhenInvoked()
        {
            // Arrange
            var viewMock = new Mock<IEditSuperheroesView>();

            Guid id = Guid.NewGuid();

            var superheroesServiceMock = new Mock<ISuperheroesService>();
            superheroesServiceMock.Setup(s => s.RestoreSuperhero(id)).Returns(1);

            EditSuperheroesPresenter superheroesPresenter = new EditSuperheroesPresenter(viewMock.Object, superheroesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnSuperheroRestore += null, new EditSuperheroesIdEventArgs(id));

            // Assert
            superheroesServiceMock.Verify(s => s.RestoreSuperhero(id), Times.Once());
        }
    }
}
