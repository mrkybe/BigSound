using System;
using System.ComponentModel.DataAnnotations;

namespace BigSound.Models
{
    [Serializable]
    public class Song
    {
        [Required]
        public Guid? Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public Guid? GroupId { get; set; }
        [Required]
        public Guid? AlbumId { get; set; }
        [Required]
        public int? NumberOnAlbum { get; set; }
        /* The song shouldn't know about this, some other service should provide this given the song's Id Guid
        [Required]
        public string FormatsAvailable { get; set; }
        */
        [Required]
        public bool? Deleted { get; set; } = false;
    }
}
