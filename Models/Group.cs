using System;
using System.ComponentModel.DataAnnotations;

namespace BigSound.Models
{
    [Serializable]
    public class Group
    {
        [Required]
        public Guid? Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Guid? ImageId { get; set; }

        [Required]
        public bool Deleted { get; set; } = false;
    }
}
