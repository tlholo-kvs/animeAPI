﻿using System;
using System.Collections.Generic;
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=simple-anime-list;Username=postgres;Password=@superT");

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
