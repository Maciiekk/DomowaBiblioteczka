﻿using DomowaBiblioteczka.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DomowaBiblioteczka.Data
{
    public class MediaDbContext : DbContext
    {

        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<MediaSection> MediaSections { get; set; }
        public DbSet<KeyWord> KeyWords { get; set; }
        public DbSet<IndustryType> IndustryTypes { get; set; }
        public MediaDbContext(DbContextOptions<MediaDbContext> options)
    : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // MediaType and Media: One-to-Many
            modelBuilder.Entity<MediaType>()
                .HasMany(mt => mt.Medias)
                .WithOne(m => m.MediaType)
                .HasForeignKey(m => m.MediaTypeID)
                .OnDelete(DeleteBehavior.Restrict);

            // Industry and IndustryType: One-to-Many
            modelBuilder.Entity<IndustryType>()
                .HasMany(it => it.industries)
                .WithOne(i => i.IndustryType)
                .HasForeignKey(i => i.IndustryTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Media and Author: One-to-Many
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Medias)
                .WithOne(m => m.Author)
                .HasForeignKey(m => m.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Media and MediaSection: One-to-Many
            modelBuilder.Entity<Media>()
                .HasMany(m => m.Sections)
                .WithOne(ms => ms.Media)
                .HasForeignKey(ms => ms.MediaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Media and KeyWord: Many-to-Many
            modelBuilder.Entity<Media>()
                .HasMany(m => m.Keywords)
                .WithMany(k => k.Medias)
                .UsingEntity(j => j.ToTable("MediaKeywords")); // Optional join table name

            // MediaSection: Additional Configuration
            modelBuilder.Entity<MediaSection>()
                .Property(ms => ms.Position)
                .IsRequired(); // Ensures Position is not null

            // Media: Additional Configuration
            modelBuilder.Entity<Media>()
                .Property(m => m.CreatedDate)
                .IsRequired();

            modelBuilder.Entity<Media>()
                .Property(m => m.ReleseDate)
                .IsRequired();

            modelBuilder.Entity<Media>()
                .Property(m=>m.Description)
                .HasMaxLength(1000)
                .IsRequired();

            modelBuilder.Entity<Media>()
                .Property(m=>m.Title) 
                .HasMaxLength(200)
                .IsRequired();

            // Industry: Additional Configuration
            modelBuilder.Entity<Industry>()
                .Property(i => i.Name)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Industry>()
                .Property(i => i.Description)
                .HasMaxLength(1000);

            // Author: Additional Configuration
            modelBuilder.Entity<Author>()
                .Property(a => a.Name)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Author>()
                .Property(a => a.Description)
                .HasMaxLength(1000);

            // MediaType: Additional Configuration
            modelBuilder.Entity<MediaType>()
                .Property(mt => mt.Name)
                .HasMaxLength(100)
                .IsRequired();

            // KeyWord: Additional Configuration
            modelBuilder.Entity<KeyWord>()
                .Property(k => k.Word)
                .HasMaxLength(100)
                .IsRequired();

            // IndustryType: Additional Configuration
            modelBuilder.Entity<IndustryType>()
                .Property(it => it.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}