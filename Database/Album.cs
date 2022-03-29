using System;

namespace BigSound.Database
{
    public class Album
    {
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Guid ImageId { get; set; }
        public bool Deleted { get; set; } = false;
    }
}
