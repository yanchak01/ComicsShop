using DAL.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class ComDbContext:DbContext
    {
        public ComDbContext(DbContextOptions<ComDbContext> options):base(options)
        {
            Database.EnsureCreated();
        }
        #region MainTables
        DbSet<Comics> Comicses { get; set; }
        DbSet<Artist> Artists { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<Corrector> Correctors { get; set; }
        DbSet<Illustrator> Illustrators { get; set; }
        DbSet<Tag> Tags { get; set; }
        #endregion
    }
}
