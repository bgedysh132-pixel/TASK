using NUnit.Framework;
using System;
using MusicLibrary;

namespace MusicLibrary.UnitTests
{
    [TestFixture]
    public class TrackUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var track = CreateTestTrack();
            
            Assert.That(track.Title, Is.EqualTo("In the End"));
            Assert.That(track.Artist, Is.EqualTo("Linkin Park"));
            Assert.That(track.ReleaseYear, Is.EqualTo(2000));
            Assert.That(track.Album, Is.EqualTo("Hybrid Theory"));
            Assert.That(track.TrackNumber, Is.EqualTo(8));
            Assert.That(track.Author, Is.EqualTo("Linkin Park"));
            Assert.That(track.Genre, Is.EqualTo(TrackGenre.Rock));
        }

        [Test]
        public void GetInfoTest()
        {
            var track = CreateTestTrack();
            var info = track.GetInfo();

            Assert.That(info.Length, Is.EqualTo(2));
            Assert.That(info[0], Is.EqualTo("Linkin Park - In the End"));
            Assert.That(info[1], Is.EqualTo("Альбом: Hybrid Theory (№8), Год: 2000, Жанр: Rock, Автор(ы): Linkin Park."));
        }

      
        private Track CreateTestTrack()
        {
            return new Track("In the End", "Linkin Park", 2000, "Hybrid Theory", 8, "Linkin Park", TrackGenre.Rock);
        }
    }
}