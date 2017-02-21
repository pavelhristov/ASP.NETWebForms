using Moq;
using NUnit.Framework;
using SuperheroesUniverse.Data.Models;
using SuperheroesUniverse.MVP.SuperheroDetails;
using SuperheroesUniverse.Services;
using System;

namespace SuperheroesUniverse.Tests.MVP.SuperheroDetails.SuperheroDetailsPresenterTests
{
    [TestFixture]
    public class View_OnSuperheroDetailsGetData_Should
    {
        [Test]
        public void AddSuperheroToViewModel_WhenOnSuperheroDetailsGetDataIsRaised()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var superhero = new Superhero()
            {
                Id = id,
                Name = "name",
                SecretIdentity = "secret identity",
                ImgUrl = "url",
                isDeleted = false
            };
            var viewMock = new Mock<ISuperheroDetailsView>();
            viewMock.Setup(v => v.Model).Returns(new SuperheroDetailsViewModel());
            var superheroesServiceMock = new Mock<ISuperheroesService>();
            superheroesServiceMock.Setup(s => s.GetById(id)).Returns(superhero);

            SuperheroDetailsPresenter superheroesPresenter = new SuperheroDetailsPresenter(viewMock.Object, superheroesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnSuperheroDetailsGetData += null, new SuperheroDetailsGetDataEventArgs(id));

            // Assert
            Assert.AreSame(superhero, viewMock.Object.Model.Superhero);
        }

        [Test]
        public void CallGetByIdWithProperParameters_WhenRaised()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var superhero = new Superhero()
            {
                Id = id,
                Name = "name",
                SecretIdentity = "secret identity",
                ImgUrl = "url",
                isDeleted = false
            };
            var viewMock = new Mock<ISuperheroDetailsView>();
            viewMock.Setup(v => v.Model).Returns(new SuperheroDetailsViewModel());
            var superheroesServiceMock = new Mock<ISuperheroesService>();
            superheroesServiceMock.Setup(s => s.GetById(id)).Returns(superhero);

            SuperheroDetailsPresenter superheroesPresenter = new SuperheroDetailsPresenter(viewMock.Object, superheroesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnSuperheroDetailsGetData += null, new SuperheroDetailsGetDataEventArgs(id));

            // Assert
            superheroesServiceMock.Verify(s => s.GetById(id), Times.Once());
        }
    }
}
