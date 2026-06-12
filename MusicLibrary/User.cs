using System;
using System.Collections;
using System.Collections.Generic;

namespace MusicLibrary
{
    public class User : IEnumerable<Track>
    {

        public string Login { get; set; }
        public string Email { get; set; }
        public string CardNumber { get; set; }


        private string _password;


        private readonly List<Track> _purchasedTracks = new List<Track>();


        public User(string login, string email, string cardNumber, string password)
        {
            if (string.IsNullOrWhiteSpace(login)) throw new ArgumentException("Логин не может быть пустым.");
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("E-mail не может быть пустым."); //

            Login = login;
            Email = email;
            CardNumber = cardNumber;
            _password = password;
        }


        public void BuyTrack(Track track)
        {
            if (track == null) throw new ArgumentNullException(nameof(track), "Трек не может быть null.");
            _purchasedTracks.Add(track);
        }


        public IEnumerator<Track> GetEnumerator()
        {
            return _purchasedTracks.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}