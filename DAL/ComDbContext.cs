using DAL.DBModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class ComDbContext: IdentityDbContext<ApplicationUser>
    {
        public ComDbContext(DbContextOptions<ComDbContext> options):base(options)
        {
            Database.Migrate();
        }

        #region MainTables
        DbSet<Comics> Comicses { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<EmployeeComics> EmployeeComics { get; set; }
        DbSet<TagComics> TagComics { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



            builder.Entity<Comics>()
                .HasMany(tc => tc.TagComicses)
                .WithOne(tc => tc.Comics)
                .HasForeignKey(tc => tc.ComicsId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Comics>()
                .HasMany(ec => ec.EmployeeComicses)
                .WithOne(ec => ec.Comics)
                .HasForeignKey(ec => ec.ComicsId)
                .OnDelete(DeleteBehavior.Cascade);

           
            builder.Entity<TagComics>().HasKey(tg => new { tg.ComicsId, tg.TagId });
            builder.Entity<EmployeeComics>().HasKey(ec => new { ec.ComicsId, ec.EmployeeId });
                
        }
    }
}
