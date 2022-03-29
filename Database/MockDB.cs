using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BigSound.Database
{
    public class MockDB
    {
        public Dictionary<Guid, Group> Groups;
        public Dictionary<Guid, Artist> Artists;
        public Dictionary<Guid, Song> Songs;
        public Dictionary<Guid, Album> Albums;


        public Dictionary<Guid, byte[]> Images;
        public Dictionary<Guid, HashSet<Guid>> AlbumSongs;
        public Dictionary<Guid, HashSet<Guid>> GroupArtists;
        public Dictionary<Guid, HashSet<Guid>> GroupAlbums;

        public MockDB()
        {
            Images = new Dictionary<Guid, byte[]>();
            
            Groups = new Dictionary<Guid, Group>();
            Artists = new Dictionary<Guid, Artist>();
            Songs = new Dictionary<Guid, Song>();
            Albums = new Dictionary<Guid, Album>();


            AlbumSongs = new Dictionary<Guid, HashSet<Guid>>();
            GroupArtists = new Dictionary<Guid, HashSet<Guid>>();
            GroupAlbums = new Dictionary<Guid, HashSet<Guid>>();
        }
    }
}
