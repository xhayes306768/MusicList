using Microsoft.AspNetCore.Mvc;
using MusicList.Models;
using System.Linq;

namespace MusicList.Controllers
{
    public class HomeController : Controller
    {
        private MusicContext context { get; set; }

        public HomeController(MusicContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var music = context.Music.OrderBy(m => m.Title).ToList();
            return View(music);
        }
    }
}
