using Microsoft.EntityFrameworkCore;
namespace MusicList.Models
{
    public class MusicContext: DbContext
    {
        
        
            public MusicContext(DbContextOptions<MusicContext> options) : base(options)
            { }
            public DbSet<Music> Movies { get; set; } = null!;
        



    }
}
