using System;
using System.Collections.Generic;
using animeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace animeAPI;

public partial class SimpleAnimeListContext : DbContext
{
    public SimpleAnimeListContext()
    {
    }

    public SimpleAnimeListContext(DbContextOptions<SimpleAnimeListContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AnimeTitle> AnimeTitles { get; set; }

    public virtual DbSet<DateReleased> DateReleaseds { get; set; }

    public virtual DbSet<NumberOfEpisode> NumberOfEpisodes { get; set; }

    public virtual DbSet<NumberOfSeason> NumberOfSeasons { get; set; }

    public virtual DbSet<RottenTomatoesRating> RottenTomatoesRatings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:simple-anime-list");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnimeTitle>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("anime_titles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<DateReleased>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("date_released");

            entity.Property(e => e.FirstAiring)
                .HasColumnType("character varying")
                .HasColumnName("first_airing");
            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<NumberOfEpisode>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("number_of_episodes");

            entity.Property(e => e.Episodes).HasColumnName("episodes");
            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<NumberOfSeason>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("number_of_seasons");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Seasons).HasColumnName("seasons");
        });

        modelBuilder.Entity<RottenTomatoesRating>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rotten_tomatoes_rating");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Rating).HasColumnName("rating");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
