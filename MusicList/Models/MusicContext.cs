using Microsoft.EntityFrameworkCore;

namespace MusicList.Models
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options) : base(options)
        { }

        public DbSet<Music> Music { get; set; } = null!;
        public DbSet<Song> Songs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Music>().HasData(new Music
            {
                MusicId = 1,
                Title = "Song Title 1",
                Artist = "Artist 1",
                Year = 2000,
                Rating = 4
            }, new Music
            {
                MusicId = 2,
                Title = "Song Title 2",
                Artist = "Artist 2",
                Year = 2010,
                Rating = 5
            });

            modelBuilder.Entity<Song>().HasData(new Song
            {
                SongId = 1,
                Title = "Song Title 1",
                Duration = new System.TimeSpan(0, 3, 30) // 3 minutes and 30 seconds
            }, new Song
            {
                SongId = 2,
                Title = "Song Title 2",
                Duration = new System.TimeSpan(0, 4, 15) // 4 minutes and 15 seconds
            });
        }
    }
}
