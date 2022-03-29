using System;
using System.ComponentModel.DataAnnotations;

namespace BigSound.Models
{
    [Serializable]
    public class Album
    {
        [Required]
        public Guid? Id { get; set; }

        [Required] 
        public Guid? GroupId { get; set; }

        [Required] 
        public DateTime? ReleaseDate { get; set; }

        [Required] 
        public Guid? ImageId { get; set; }

        [Required] 
        public bool? Deleted { get; set; } = false;
    }
}
