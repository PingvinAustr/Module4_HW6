using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Module4_HW6.Configurations;
using Module4_HW6.Models;

namespace Module4_HW6
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<ArtistsSongs> ArtistsSongs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(
                new ArtistConfiguration());
            modelBuilder.ApplyConfiguration(
               new SongConfiguration());
            modelBuilder.ApplyConfiguration(
               new GenreConfiguration());
            modelBuilder.ApplyConfiguration(
                new ArtistsSongsConfiguration());

            modelBuilder.Entity<Genre>().HasData(new List<Genre>
            {
               new Genre
               {
                   GenreName = "Rock",
                   GenreId = 1,
               },
               new Genre
               {
                   GenreName = "Pop",
                   GenreId = 2,
               },
               new Genre
               {
                   GenreName = "Folk",
                   GenreId = 3,
               },
               new Genre
               {
                   GenreName = "Rap",
                   GenreId = 4,
               },
               new Genre
               {
                   GenreName = "Electro",
                   GenreId = 5,
               },
            });

            modelBuilder.Entity<Song>().HasData(new List<Song>
            {
                new Song
                {
                    SongTitle = "Rap god",
                    SongId = 1,
                    SongDuration = 363,
                    ReleaseDate = new DateTime(2013, 11, 27),
                    GenreId = 4
                },
                new Song
                {
                    SongTitle = "Deutschland",
                    SongId = 2,
                    SongDuration = 323,
                    ReleaseDate = new DateTime(2019, 3, 28),
                    GenreId = 1
                },
                new Song
                {
                    SongTitle = "Oy U Luzi Chervona Kalyna",
                    SongId = 3,
                    SongDuration = 195,
                    ReleaseDate = new DateTime(1914, 1, 2),
                    GenreId = 3
                },
                new Song
                {
                    SongTitle = "Moves like Jagger",
                    SongId = 4,
                    SongDuration = 201,
                    ReleaseDate = new DateTime(2011, 8, 9),
                    GenreId = 2
                },
                new Song
                {
                    SongTitle = "Alone",
                    SongId = 5,
                    SongDuration = 162,
                    ReleaseDate = new DateTime(2016, 12, 2),
                    GenreId = 5
                },
            });

            modelBuilder.Entity<Artist>().HasData(new List<Artist>
            {
                new Artist
                {
                    ArtistId = 1,
                    ArtistName = "Rammstein",
                    DateOfBirth = new DateTime(1994, 1, 1),
                    Phone = "380632140021",
                    Email = string.Empty,
                    InstagramUrl
                    = "https://www.instagram.com/rammsteinofficial/",
                },
                new Artist
                {
                    ArtistId = 2,
                    ArtistName = "Eminem",
                    DateOfBirth = new DateTime(1972, 10, 17),
                    Phone = string.Empty,
                    Email = string.Empty,
                    InstagramUrl
                    = "https://www.instagram.com/eminem/",
                },
                new Artist
                {
                    ArtistId = 3,
                    ArtistName = "Maroon 5",
                    DateOfBirth = new DateTime(2001, 1, 1),
                    Phone = string.Empty,
                    Email = string.Empty,
                    InstagramUrl
                    = "https://www.instagram.com/maroon5/",
                },
                new Artist
                {
                    ArtistId = 4,
                    ArtistName = "Alan Walker",
                    DateOfBirth = new DateTime(1997, 8, 24),
                    Phone = string.Empty,
                    Email = string.Empty,
                    InstagramUrl
                    = "https://www.instagram.com/alanwalkermusic/",
                },
                new Artist
                {
                    ArtistId = 5,
                    ArtistName = "Ukraine",
                    DateOfBirth = DateTime.Now,
                    Phone = string.Empty,
                    Email = string.Empty,
                    InstagramUrl = string.Empty,
                },
                new Artist
                {
                    ArtistId = 6,
                    ArtistName = "ReSinger",
                    DateOfBirth = DateTime.Now,
                    Phone = string.Empty,
                    Email = string.Empty,
                    InstagramUrl = string.Empty,
                },
            });

            modelBuilder.Entity<ArtistsSongs>().HasData(new List<ArtistsSongs>
            {
                new ArtistsSongs
                {
                    ArtistsSongsId = 1,
                    SongId = 1,
                    ArtistId = 2
                },
                new ArtistsSongs
                {
                    ArtistsSongsId = 2,
                    SongId = 2,
                    ArtistId = 1
                },
                new ArtistsSongs
                {
                    ArtistsSongsId = 3,
                    SongId = 3,
                    ArtistId = 5
                },
                new ArtistsSongs
                {
                    ArtistsSongsId = 4,
                    SongId = 4,
                    ArtistId = 3
                },
                new ArtistsSongs
                {
                    ArtistsSongsId = 5,
                    SongId = 5,
                    ArtistId = 4
                },
                new ArtistsSongs
                {
                    ArtistsSongsId = 6,
                    SongId = 1,
                    ArtistId = 6
                },
                new ArtistsSongs
                {
                    ArtistsSongsId = 7,
                    SongId = 2,
                    ArtistId = 6
                },
                new ArtistsSongs
                {
                    ArtistsSongsId = 8,
                    SongId = 3,
                    ArtistId = 6
                },
                new ArtistsSongs
                {
                    ArtistsSongsId = 9,
                    SongId = 4,
                    ArtistId = 6
                },
                new ArtistsSongs
                {
                    ArtistsSongsId = 10,
                    SongId = 5,
                    ArtistId = 6
                }
            });
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("config.json")
            .Build();
            optionsBuilder
                .UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
