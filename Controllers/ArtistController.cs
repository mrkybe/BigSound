using BigSound.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Artist = BigSound.Models.Artist;

namespace BigSound.Controllers
{
    public class ArtistController : Controller
    {
        private readonly MockDB mockDB;

        public ArtistController()
        {
            mockDB = new MockDB();
        }

        public JsonResult GetAllArtistNames()
        {
            var names = mockDB.Artists.Values.Where(s => !s.Deleted).Select(s => s.Name).ToList();
            return Json(names);
        }

        public JsonResult GetArtist(Guid Id)
        {
            return Json(mockDB.Artists.Values.Where(s => !s.Deleted).SingleOrDefault(s => s.Id == Id));
        }

        // Todo: Implement Model Binder for Artist class
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateArtist([ModelBinder] Artist artist)
        {
            if (ModelState.IsValid)
            {
                mockDB.Artists[artist.Id.Value] = artist.ToDBObject();
            }
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddNewArtist(string Name, Guid? ImageId)
        {
            Guid newArtistGuid = Guid.NewGuid();

            // maybe check if an artist with the same name already exists?

            mockDB.Artists.Add(newArtistGuid, new BigSound.Database.Artist()
            {
                Id = newArtistGuid,
                Name = Name,
                ImageId = ImageId ?? Guid.Empty
            });

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteArtist(Guid Id)
        {
            if (mockDB.Artists.ContainsKey(Id))
            {
                mockDB.Artists[Id].Deleted = true;
            }

            return View();
        }
    }
}
