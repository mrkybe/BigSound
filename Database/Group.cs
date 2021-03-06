using System;

namespace BigSound.Database
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ImageId { get; set; }
        public bool Deleted { get; set; } = false;
    }
}
