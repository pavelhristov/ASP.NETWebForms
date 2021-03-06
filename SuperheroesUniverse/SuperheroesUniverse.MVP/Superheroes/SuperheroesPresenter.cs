﻿using Bytes2you.Validation;
using SuperheroesUniverse.Services;
using System;
using WebFormsMvp;

namespace SuperheroesUniverse.MVP.Superheroes
{
    public class SuperheroesPresenter : Presenter<ISuperheroesView>
    {
        private readonly ISuperheroesService superheroesService;

        public SuperheroesPresenter(ISuperheroesView view, ISuperheroesService superheroesService)
            : base(view)
        {
            Guard.WhenArgument(superheroesService, nameof(superheroesService)).IsNull().Throw();

            this.superheroesService = superheroesService;

            this.View.OnSuperheroesGetData += this.View_OnSuperheroesGetData;
        }

        private void View_OnSuperheroesGetData(object sender, EventArgs e)
        {
            this.View.Model.Superheroes = this.superheroesService.GetAll();
        }
    }
}
