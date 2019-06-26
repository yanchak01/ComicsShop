using DAL.DBModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ComicsDbContext: IdentityDbContext<ApplicationUser>
    {
        public ComicsDbContext(DbContextOptions<ComicsDbContext> options):base(options)
        {
            Database.Migrate();
        }

        #region Tables
        DbSet<Comics> Comicses { get; set; }
        DbSet<ComicsAuthor> ComicsAuthors { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<ComicsAuthorComics> ComicsAuthorComics { get; set; }
        DbSet<TagComics> TagComics { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



            builder.Entity<Comics>()
                .HasMany(tc => tc.Tags)
                .WithOne(tc => tc.Comics)
                .HasForeignKey(tc => tc.ComicsId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Comics>()
                .HasMany(ec => ec.Authors)
                .WithOne(ec => ec.Comics)
                .HasForeignKey(ec => ec.ComicsId)
                .OnDelete(DeleteBehavior.Cascade);

           
            builder.Entity<TagComics>().HasKey(tg => new { tg.ComicsId, tg.TagId });
            builder.Entity<ComicsAuthorComics>().HasKey(ec => new { ec.ComicsId, ec.ComicsAuthorId });
                
        }
    }
}
