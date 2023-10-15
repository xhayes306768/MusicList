using Microsoft.AspNetCore.Mvc;
using MusicList.Models;
using System.Linq;

namespace MusicList.Controllers
{
    public class MusicController : Controller
    {
        private MusicContext context { get; set; }

        public MusicController(MusicContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Music());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var music = context.Music.Find(id);
            return View(music);
        }

        [HttpPost]
        public IActionResult Edit(Music music)
        {
            if (ModelState.IsValid)
            {
                if (music.MusicId == 0)
                    context.Music.Add(music);
                else
                    context.Music.Update(music);

                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (music.MusicId == 0) ? "Add" : "Edit";
                return View(music);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var music = context.Music.Find(id);
            return View(music);
        }

        [HttpPost]
        public IActionResult Delete(Music music)
        {
            context.Music.Remove(music);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}

