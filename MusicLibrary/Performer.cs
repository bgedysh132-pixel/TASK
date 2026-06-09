using System;

namespace MusicLibrary
{
    public abstract class Performer
    {
        public string Country { get; set; }

        public Performer(string country)
        {
            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Страна не может быть пустой.");

            Country = country;
        }

        
        public abstract string[] GetInfo();
    }
}