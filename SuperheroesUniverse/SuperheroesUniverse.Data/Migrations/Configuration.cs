namespace SuperheroesUniverse.Data.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SuperheroesUniverseContext>
    {
        public Configuration()
        {
            // dev purposes! TODO: don't forget in release!
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SuperheroesUniverseContext context)
        {
            if (context.Superheroes.Any())
            {
                return;
            }

            IList<Superhero> superheroes = new List<Superhero>()
            {
                new Superhero()
                {
                    Id = Guid.NewGuid(),
                    Name = "Batman",
                    SecretIdentity = "Bruce Wayne",
                    ImgUrl = "https://s-media-cache-ak0.pinimg.com/736x/3d/bf/32/3dbf32ffdf36a469d2fb30ba0ad0feef.jpg"
                },
                new Superhero()
                {
                    Id = Guid.NewGuid(),
                    Name = "Iron man",
                    SecretIdentity = "Tony Stark",
                    ImgUrl = "http://vignette3.wikia.nocookie.net/ironman/images/4/4f/Photo(1073).png/revision/latest?cb=20150417140445"
                }
            };
            
            context.Superheroes.AddOrUpdate(superheroes.ToArray());

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
