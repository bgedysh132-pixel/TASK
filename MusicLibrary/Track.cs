using System;

namespace MusicLibrary
{
    public class Track
    {
        public string Title { get; set; }

        
        public Performer Artist { get; set; }

        public int ReleaseYear { get; set; }
        public string Album { get; set; }
        public int TrackNumber { get; set; } = 0;
        public string Author { get; set; }
        public TrackGenre Genre { get; set; }

        public Track(string title, Performer artist, int releaseYear, string album, int trackNumber, string author, TrackGenre genre)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Название трека не может быть пустым.");

            Title = title;
            Artist = artist ?? throw new ArgumentNullException(nameof(artist), "Исполнитель не может быть null.");
            ReleaseYear = releaseYear;
            Album = album;
            TrackNumber = trackNumber;
            Author = author;
            Genre = genre;
        }

        public virtual string[] GetInfo()
        {
            var info = new string[2];
            
            var performerName = Artist.GetInfo()[0];

            info[0] = $"{performerName} - {Title}";
            info[1] = $"Альбом: {Album} (№{TrackNumber}), Год: {ReleaseYear}, Жанр: {Genre}, Автор(ы): {Author}.";
            return info;
        }
    }
}