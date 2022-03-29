using System;

namespace BigSound.Database
{
    public class Song
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid GroupId { get; set; }
        public Guid AlbumId { get; set; }
        public int NumberOnAlbum { get; set; }
        public string FormatsAvailable { get; set; }
        public bool Deleted { get; set; } = false;
    }
}
