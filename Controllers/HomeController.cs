using BigSound.Database;
using BigSound.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace BigSound.Controllers
{
    public class HomeController : Controller
    {
        private readonly MockDB mockDB;

        public HomeController()
        {
            mockDB = new MockDB();
        }

        [HttpGet]
        public IActionResult GetArtistDiscography(Guid ArtistId)
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetArtistMostRecentAlbum(Guid ArtistId)
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetGroupMostRecentAlbum(Guid ArtistId)
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAlbumSongs(Guid AlbumId)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
