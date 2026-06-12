using NUnit.Framework;
using System;
using MusicLibrary;

namespace MusicLibrary.UnitTests
{
    [TestFixture]
    public class PerformerUnitTests
    {
        [Test]
        public void SoloPerformer_GetInfoTest()
        {
            var edSheeran = new SoloPerformer("Великобритания", "Ed", "Sheeran", "17.02.1991");
            var info = edSheeran.GetInfo();

            Assert.That(info.Length, Is.EqualTo(2));
            Assert.That(info[0], Is.EqualTo("Ed Sheeran"));
            Assert.That(info[1], Is.EqualTo("Страна: Великобритания. Дата рождения: 17.02.1991."));
        }

        [Test]
        public void Band_GetInfoTest()
        {
            string[] members = { "Chester Bennington", "Mike Shinoda", "Brad Delson", "Dave Farrell", "Joe Hahn", "Rob Bourdon" };
            var linkinPark = new Band("США", "Linkin Park", members, 1996);

            var info = linkinPark.GetInfo();

            Assert.That(info.Length, Is.EqualTo(2));
            Assert.That(info[0], Is.EqualTo("Linkin Park"));
            Assert.That(info[1], Is.EqualTo("Страна: США. Год образования: 1996. Состав: Chester Bennington, Mike Shinoda, Brad Delson, Dave Farrell, Joe Hahn, Rob Bourdon."));
        }

        [Test]
        public void UpdatedTrack_GetInfoTest()
        {
            
            Performer band = new Band("США", "Linkin Park", new[] { "Chester", "Mike" }, 1996);

            
            var track = new Track("In the End", band, 2000, "Hybrid Theory", 8, "Linkin Park", TrackGenre.Rock);

            var info = track.GetInfo();

            Assert.That(info.Length, Is.EqualTo(2));
            
            Assert.That(info[0], Is.EqualTo("Linkin Park - In the End"));
            Assert.That(info[1], Is.EqualTo("Альбом: Hybrid Theory (№8), Год: 2000, Жанр: Rock, Автор(ы): Linkin Park.")); //
        }
    }
}