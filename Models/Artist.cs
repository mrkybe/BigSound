using System;
using System.ComponentModel.DataAnnotations;

namespace BigSound.Models
{
    [Serializable]
    public class Artist
    {
        [Required]
        public Guid? Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Guid? ImageId { get; set; }

        [Required]
        public bool? Deleted { get; set; } = false;

        public Database.Artist ToDBObject()
        {
            return new Database.Artist()
            {
                Id = Id.Value,
                Name = Name,
                ImageId = ImageId,
                Deleted = Deleted.Value
            };
        }
    }
}
