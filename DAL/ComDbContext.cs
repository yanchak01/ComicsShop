using DAL.DBModels;
using DAL.UserModels;
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

        #region IntermediateTables
        DbSet<ArtistComics> ArtistComics { get; set; }
        DbSet<AuthorComics> AuthorComics { get; set; }
        DbSet<CorrectorComics> CorrectorComics { get; set; }
        DbSet<IllustratorComics> IllustratorComics { get; set; }
        DbSet<PublisherComics> PublisherComics { get; set; }
        DbSet<TagComics> TagComics { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Comics>()
                .HasMany(ac => ac.ArtistComicses)
                .WithOne(ac => ac.Comics)
                .HasForeignKey(ac => ac.ComicsId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Comics>()
                .HasMany(ac => ac.AuthorComicses)
                .WithOne(ac => ac.Comics)
                .HasForeignKey(ac => ac.ComicsId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Comics>()
                .HasMany(cc => cc.CorrectorsComicses)
                .WithOne(cc => cc.Comics)
                .HasForeignKey(cc => cc.ComicsId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Comics>()
                .HasMany(ic => ic.IllustratorComicses)
                .WithOne(ic => ic.Comics)
                .HasForeignKey(ic => ic.ComicsId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Comics>()
                .HasMany(pc => pc.PublisherComicses)
                .WithOne(pc => pc.Comics)
                .HasForeignKey(pc => pc.ComicsId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Comics>()
                .HasMany(tc => tc.TagComicses)
                .WithOne(tc => tc.Comics)
                .HasForeignKey(tc => tc.ComicsId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Artist>()
                .HasMany(ac => ac.ArtistComicses)
                .WithOne(ac => ac.Artist)
                .HasForeignKey(ac => ac.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Author>()
               .HasMany(ac => ac.AuthorComicses)
               .WithOne(ac => ac.Author)
               .HasForeignKey(ac => ac.AuthorId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Corrector>()
               .HasMany(ac => ac.CorrectorsComicses)
               .WithOne(ac => ac.Corrector)
               .HasForeignKey(ac => ac.CorrectorId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Illustrator>()
               .HasMany(ac => ac.IllustratorComicses)
               .WithOne(ac => ac.Illustrator)
               .HasForeignKey(ac => ac.IllustratorId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Publisher>()
                .HasMany(pc => pc.PublisherComicses)
                .WithOne(pc => pc.Publisher)
                .HasForeignKey(pc => pc.PublisherId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Tag>()
                .HasMany(tg => tg.TagComicses)
                .WithOne(tg => tg.Tag)
                .HasForeignKey(tg => tg.TagId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ArtistComics>().HasKey(ac => new { ac.ArtistId, ac.ComicsId });
            builder.Entity<AuthorComics>().HasKey(ac => new { ac.AuthorId, ac.ComicsId });
            builder.Entity<CorrectorComics>().HasKey(cc => new { cc.CorrectorId, cc.ComicsId });
            builder.Entity<IllustratorComics>().HasKey(ic => new { ic.ComicsId, ic.IllustratorId });
            builder.Entity<PublisherComics>().HasKey(pc => new { pc.ComicsId, pc.PublisherId });
            builder.Entity<TagComics>().HasKey(tg => new { tg.ComicsId, tg.TagId });
                
        }
    }
}
