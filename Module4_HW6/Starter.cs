using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Module4_HW6
{
    public static class Starter
    {
        public static void PrintInColor(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Run()
        {
            var optionsBuilder =
               new DbContextOptionsBuilder<DatabaseContext>();
            var options = optionsBuilder.Options;
            using (DatabaseContext db = new DatabaseContext(options))
            {
                db.SaveChanges();
                Console.WriteLine("DB creation operation has been performed," +
                    "please check your SQL server");

                // ===== QUERY1 =====
                PrintInColor("\n\nQUERY 1.DISPLAY SONG NAME," +
                    "ARTIST NAME, GENRE NAME." +
                    "GENRE AND ARTIST SHOULD EXIST\n--------------");
                var query1 = from a in db.ArtistsSongs
                                join artists in db.Artists
                                on a.ArtistId equals artists.ArtistId
                                join songs in db.Songs
                                on a.SongId equals songs.SongId
                                join genres in db.Genres
                                on songs.GenreId equals genres.GenreId
                                where songs.GenreId != null
                                && artists.ArtistId != null
                                select new
                                {
                                    SongTitle = songs.SongTitle,
                                    ArtistName = artists.ArtistName,
                                    GenreName = genres.GenreName
                                };

                PrintInColor(query1.ToQueryString()
                    + "\n--------------\nSong - Artist - Genre");
                foreach (var item in query1)
                {
                        Console.WriteLine($"{item.SongTitle}" +
                            $"-{item.ArtistName}-{item.GenreName}");
                }

                // ===== QUERY2 =====
                PrintInColor("\n\nQUERY 2.DISPLAY NUMBER" +
                    "OF SONGS IN EACH GENRE\n--------------");
                var query2 = from genres in db.Genres
                                join songs in db.Songs
                                on genres.GenreId equals songs.GenreId
                                group genres by genres.GenreName into grouped
                                select new
                                {
                                    GenreName = grouped.Key,
                                    Number = grouped.Count()
                                };
                PrintInColor(query2.ToQueryString() +
                    "\n--------------\nGenre-Number of songs");
                foreach (var item in query2)
                {
                        Console.WriteLine($"{item.GenreName}-{item.Number}");
                }

                // ===== QUERY3 =====
                PrintInColor("\n\nQUERY 3. DISPLAY SONGS WITH" +
                    "RELEASEDATE<=BIRTHDATE OF THE YOUNGEST ARTIST");
                var query3 = from s in db.Songs
                            join a in db.ArtistsSongs
                            on s.SongId equals a.SongId
                            join ar in db.Artists
                            on a.ArtistId equals ar.ArtistId
                            where s.ReleaseDate
                            < db.Artists.Min(a => a.DateOfBirth)
                            select new
                            {
                                SongTitle = s.SongTitle,
                                ReleaseDate = s.ReleaseDate,
                                ArtistName = ar.ArtistName
                            };
                var youngestArtistBirthdate
                    = db.Artists.Min(a => a.DateOfBirth);
                Console.WriteLine("Youngest artist birth date - "
                    + youngestArtistBirthdate);
                PrintInColor(query3.ToQueryString() +
                    "\n--------------\nSong-release date - artist name");
                foreach (var item in query3)
                {
                    Console.WriteLine($"{item.SongTitle}" +
                        $"- {item.ReleaseDate} - {item.ArtistName}");
                }
            }
        }
    }
}
