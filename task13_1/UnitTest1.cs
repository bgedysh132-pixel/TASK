using System;
using NUnit.Framework; 

namespace StreamingLibrary
{
    
    public enum TrackGenre
    {
        Pop,
        Rock,
        HipHop,
        Jazz,
        Classical,
        Electronic,
        Metal
    }

    
    public class Track
    {
        
        public string Title { get; set; }        
        public string Artist { get; set; }       
        public int Year { get; set; }            
        public string Album { get; set; }         
        public int TrackNumber { get; set; }     
        public string Authors { get; set; }       

        
        public readonly TrackGenre Genre;

        
        public Track(string title, string artist, int year, string album, int trackNumber, string authors, TrackGenre genre)
        {
            Title = title;
            Artist = artist;
            Year = year;
            Album = album;
            TrackNumber = trackNumber;
            Authors = authors;
            Genre = genre;
        }

        
        public virtual string[] GetInfo()
        {
            var info = new string[2]; 

            info[0] = $"{Artist} - {Title}"; 
            info[1] = $"Альбом: {Album} (Трек №{TrackNumber}). Год: {Year}. Авторы: {Authors}. Жанр: {Genre}."; 

            return info;
        }
    }

    
    [cite_start]
    [TestFixture] 
    public class TrackUnitTests
    {
        [cite_start]
        [Test] 
        public void ConstructorTest()
        {
            [cite_start]
            var track = CreateTestTrack();

            [cite_start]
            Assert.That(track.Title, Is.EqualTo("Bohemian Rhapsody"));
            Assert.That(track.Artist, Is.EqualTo("Queen"));
            Assert.That(track.Year, Is.EqualTo(1975));
            Assert.That(track.Album, Is.EqualTo("A Night at the Opera"));
            Assert.That(track.TrackNumber, Is.EqualTo(11));
            Assert.That(track.Authors, Is.EqualTo("Freddie Mercury"));
            Assert.That(track.Genre, Is.EqualTo(TrackGenre.Rock));
        }

        [cite_start]
        [Test]
        public void GetInfoTest()
        {
            var track = CreateTestTrack();
            var info = track.GetInfo(); 

            [cite_start]
            [cite_start] Assert.That(info.Length, Is.EqualTo(2)); [cite: 106]
            [cite_start] Assert.That(info[0], Is.EqualTo("Queen - Bohemian Rhapsody")); [cite: 107]
            Assert.That(info[1], Is.EqualTo("Альбом: A Night at the Opera (Трек №11). Год: 1975. Авторы: Freddie Mercury. Жанр: Rock."));
        }

        [cite_start]
        private Track CreateTestTrack()
        {
            return new Track(
                "Bohemian Rhapsody",
                "Queen",
                1975,
                "A Night at the Opera",
                11,
                "Freddie Mercury",
                TrackGenre.Rock
            );
        }
    }
}