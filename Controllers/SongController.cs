using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigSound.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigSound.Controllers
{
    public class SongController : Controller
    {
        private readonly MockDB mockDB;

        public SongController()
        {
            mockDB = new MockDB();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddNewSong(string Title, int NumberOnAlbum, Guid AlbumId)
        {
            Guid newSongGuid = Guid.NewGuid();

            // maybe check if NumberOnAlbum already exists?

            mockDB.Songs.Add(newSongGuid, new BigSound.Database.Song()
            {
                Id = newSongGuid,
                Title = Title,
                AlbumId = AlbumId,
                GroupId = GetGroupIdFromAlbumId(AlbumId),
                NumberOnAlbum = NumberOnAlbum,

            });

            return View();
        }

        private Guid GetGroupIdFromAlbumId(Guid AlbumId)
        {
            throw new NotImplementedException();
            return Guid.NewGuid();
        }
    }
}
