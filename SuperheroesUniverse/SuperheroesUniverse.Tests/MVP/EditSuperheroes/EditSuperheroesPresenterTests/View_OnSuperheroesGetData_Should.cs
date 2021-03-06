﻿using Moq;
using NUnit.Framework;
using SuperheroesUniverse.MVP.EditSuperheroes;
using SuperheroesUniverse.Services;
using SuperheroesUniverse.Tests.Helpers;
using System;
using System.Linq;

namespace SuperheroesUniverse.Tests.MVP.EditSuperheroes.EditSuperheroesPresenterTests
{
    [TestFixture]
    public class View_OnSuperheroesGetData_Should
    {
        [Test]
        public void AddSuperheroesToViewModel_WhenOnSuperheroesGetDataIsRaised()
        {
            // Arrange
            var superheroes = Helper.GetSuperheroes().AsQueryable();
            var viewMock = new Mock<IEditSuperheroesView>();
            viewMock.Setup(v => v.Model).Returns(new EditSuperheroesViewModel());
            var superheroesServiceMock = new Mock<ISuperheroesService>();
            superheroesServiceMock.Setup(s => s.ManagementGetAll()).Returns(superheroes);

            EditSuperheroesPresenter superheroesPresenter = new EditSuperheroesPresenter(viewMock.Object, superheroesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnSuperheroesGetData += null, EventArgs.Empty);

            // Assert
            CollectionAssert.AreEquivalent(superheroes, viewMock.Object.Model.Superheroes);
        }
    }
}
