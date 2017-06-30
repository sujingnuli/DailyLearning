using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GJBCTest.Website.Models
{
    public class MusicStoreDBInitializer:DropCreateDatabaseAlways<MusicStoreDBContext>
    {
        protected override void Seed(MusicStoreDBContext context)
        {
            context.Genres.Add(new Genre { Name = "Jazz" });
            context.Artists.Add(new Artist { Name = "Ay liy" });
            context.Albums.Add(new Album
            {
                Artist = new Artist { Name = "Adam Lambert" },
                Genre = new Genre { Name = "Rock" },
                Title = "What do you want from me",
                Price = 4.5m
            });
            base.Seed(context);
        }
    }
}