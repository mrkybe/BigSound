using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BigSound.Models;
using BigSound.Database;
using Microsoft.AspNetCore.Authorization;
using Artist = BigSound.Models.Artist;

namespace BigSound.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MockDB mockDB;

        public HomeController(ILogger<HomeController> logger)
        {
            mockDB = new MockDB();
            _logger = logger;
        }

        public JsonResult GetAllArtistNames()
        {
            var names = mockDB.Artists.Values.Where(s => !s.Deleted).Select(s => s.Name).ToList();
            return Json(names);
        }

        /*
         * more of the same thing as above to get Songs/Groups/Albums
         */

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddNewArtist(string Name, Guid? ImageId)
        {
            Guid newArtistGuid = Guid.NewGuid();

            // maybe check if an artist with the same name already exists?

            mockDB.Artists.Add(newArtistGuid, new BigSound.Database.Artist()
            {
                Id = Guid.NewGuid(),
                Name = Name,
                ImageId = ImageId ?? Guid.Empty
            });

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddNewGroup(string Name, Guid? ImageId)
        {
            Guid newGroupGuid = Guid.NewGuid();

            mockDB.Groups.Add(newGroupGuid, new BigSound.Database.Group()
            {
                Id = Guid.NewGuid(),
                Name = Name,
                ImageId = ImageId ?? Guid.Empty,
                Deleted = false
            });

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteGroup(Guid Id)
        {
            if(mockDB.Groups.ContainsKey(Id))
            {
                mockDB.Groups[Id].Deleted = true;
            }

            return View();
        }

        /*
         * other 'deletes' similar to this
         */

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateArtist([ModelBinder] Artist artist)
        {
            if(ModelState.IsValid)
            {
                mockDB.Artists[artist.Id.Value] = artist.ToDBObject();
            }
            return View();
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
