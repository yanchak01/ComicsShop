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
        public DbSet<Comics> Comicses { get; set; }
        public DbSet<ComicsAuthor> ComicsAuthors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ComicsAuthorComics> ComicsAuthorComics { get; set; }
        public DbSet<TagComics> TagComics { get; set; }
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

            builder.Entity<ComicsAuthor>()
                .HasMany(ec => ec.Authors)
                .WithOne(ec => ec.ComicsAuthor)
                .HasForeignKey(ec => ec.ComicsAuthorId)
                .OnDelete(DeleteBehavior.Cascade);

           
            builder.Entity<TagComics>().HasKey(tg => new { tg.ComicsId, tg.TagId });
            builder.Entity<ComicsAuthorComics>().HasKey(ec => new { ec.ComicsId, ec.ComicsAuthorId });
                
        }
    }
}
