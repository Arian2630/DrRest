using DrRest.Models;

namespace DrRest.Managers
{
    public class MusicManager
    {
        public static int _nextId = 1;
        public static readonly List<Music> Data = new List<Music>
        {
            new Music {Id= _nextId++, Title = "Feed the Machine", Artist = "Poor Man's Poison", Duration = 3.03, publicationYear = 2020 },
            new Music {Id= _nextId++, Title = "Three Little Birds", Artist = "Bob Marley", Duration = 3.01, publicationYear = 1977 },
            new Music {Id= _nextId++, Title = "I won't", Artist = "AJR", Duration = 2.48, publicationYear = 2022 },
            new Music {Id= _nextId++, Title = "Naked", Artist = "FINNEAS", Duration = 2.47, publicationYear = 2022 },
            new Music {Id= _nextId++, Title = "Dare", Artist = "Gorillaz", Duration = 4.10, publicationYear = 2005 },
        };
        public List<Music> GetAll(string? searchString)
        {

            if (string.IsNullOrEmpty(searchString))
                return new List<Music>(Data);

            return new List<Music>(Data)
                .Where(m =>
                    m.Title.Contains(searchString, StringComparison.CurrentCultureIgnoreCase) ||
                    m.Artist.Contains(searchString, StringComparison.CurrentCultureIgnoreCase) ||
                    m.Duration.ToString().Contains(searchString, StringComparison.CurrentCultureIgnoreCase) ||
                    m.publicationYear.ToString().Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                ).ToList();
        }
        public Music GetById(int Id)
        {
            return Data.Find(musics => musics.Id == Id);
        }
        public Music Add(Music newMusic)
        {
            newMusic.Id = _nextId++;
            Data.Add(newMusic);
            return newMusic;
        }
        public Music Delete(int Id)
        {
            Music musics = Data.Find(music => music.Id == Id);
            if (musics == null) return null;
            Data.Remove(musics);
            return musics;

        }
        public Music Update (int Id, Music updates)
        {
            Music musics = Data.Find(music => music.Id == Id);
            if (musics == null) return null;
            musics.Title = updates.Title;
            musics.Artist = updates.Artist;
            musics.Duration = updates.Duration;
            musics.publicationYear = updates.publicationYear;
            return musics;
        }
        
    }
}
