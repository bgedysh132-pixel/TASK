using NUnit.Framework;
using System;
using System.Collections.Generic;
using MusicLibrary;

namespace MusicLibrary.UnitTests
{
    [TestFixture]
    public class InterfaceUnitTests
    {
        [Test]
        public void TrackSorting_ShouldSortByArtistThenByTitle()
        {
            Performer linkinPark = new Band("США", "Linkin Park", new[] { "Chester" }, 1996);
            Performer edSheeran = new SoloPerformer("Великобритания", "Ed", "Sheeran", "17.02.1991");

            var track1 = new Track("Numb", linkinPark, 2003, "Meteora", 13, "LP", TrackGenre.Rock);
            var track2 = new Track("In the End", linkinPark, 2000, "Hybrid Theory", 8, "LP", TrackGenre.Rock);
            var track3 = new Track("Shape of You", edSheeran, 2017, "Divide", 4, "Ed", TrackGenre.Pop);

            var trackList = new List<Track> { track1, track2, track3 };

            trackList.Sort();

            Assert.That(trackList[0].Title, Is.EqualTo("Shape of You"));
            Assert.That(trackList[1].Title, Is.EqualTo("In the End"));
            Assert.That(trackList[2].Title, Is.EqualTo("Numb"));
        }

        [Test]
        public void User_ShouldActAsCollectionOfPurchasedTracks()
        {
            var user = new User("music_fan", "fan@example.com", "1111-2222-3333-4444", "securePass1");
            Performer band = new Band("США", "Linkin Park", new[] { "Chester" }, 1996);
            var track = new Track("In the End", band, 2000, "Hybrid Theory", 8, "LP", TrackGenre.Rock); //

            user.BuyTrack(track);

            int itemsCount = 0;
            string lastTrackTitle = "";

            foreach (Track purchasedTrack in user)
            {
                itemsCount++;
                lastTrackTitle = purchasedTrack.Title;
            }

            Assert.That(itemsCount, Is.EqualTo(1));
            Assert.That(lastTrackTitle, Is.EqualTo("In the End"));
        }
    }
}