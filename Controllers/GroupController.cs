using BigSound.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BigSound.Controllers
{
    public class GroupController : Controller
    {
        private readonly MockDB mockDB;

        public GroupController()
        {
            mockDB = new MockDB();
        }

        public JsonResult GetGroup(Guid Id)
        {
            if(mockDB.Groups.ContainsKey(Id))
            {
                return Json(new Models.Group(mockDB.Groups[Id]));
            }
            else
            {
                return Json(new EmptyResult());
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddNewGroup(string Name, Guid? ImageId)
        {
            Guid newGroupGuid = Guid.NewGuid();

            mockDB.Groups.Add(newGroupGuid, new BigSound.Database.Group()
            {
                Id = newGroupGuid,
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
            if (mockDB.Groups.ContainsKey(Id))
            {
                mockDB.Groups[Id].Deleted = true;
            }

            return View();
        }
    }
}
