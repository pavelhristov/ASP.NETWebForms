using SuperheroesUniverse.Data.Models;
using System;
using System.Collections.Generic;

namespace SuperheroesUniverse.Tests.Helpers
{
    public class Helper
    {
        public static IEnumerable<Superhero> GetSuperheroes()
        {
            return new List<Superhero>()
            {
                new Superhero()
                {
                    Id = Guid.NewGuid(),
                    Name = "name 1",
                    SecretIdentity = "secret identity 1",
                    ImgUrl = "image url 1",
                    isDeleted = false
                },new Superhero()
                {
                    Id = Guid.NewGuid(),
                    Name = "name 2",
                    SecretIdentity = "secret identity 2",
                    ImgUrl = "image url 2",
                    isDeleted = false
                },new Superhero()
                {
                    Id = Guid.NewGuid(),
                    Name = "name 3",
                    SecretIdentity = "secret identity 3",
                    ImgUrl = "image url 3",
                    isDeleted = true
                }
            };
        }
    }
}
