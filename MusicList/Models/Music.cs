using System.ComponentModel.DataAnnotations;

namespace MusicList.Models
{
    public class Music
    {
        // EF Core will configure the database to generate this value

        public int MusicId { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the artist.")]
        public string Artist { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the year.")]
        [Range(1889, 2999, ErrorMessage = "Year must be after 1889.")]
        public int? Year { get; set; }

        [Required(ErrorMessage = "Please enter a rating.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int? Rating { get; set; }

        // Add a collection to store songs associated with the music
        public ICollection<Song> Songs { get; set; }


    }
    public class Song
    {
        public int SongId { get; set; }

        [Required(ErrorMessage = "Please enter a song title.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the duration.")]
        public TimeSpan Duration { get; set; }

    }

}
