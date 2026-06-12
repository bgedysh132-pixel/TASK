using System;

namespace MusicLibrary
{
    public class SoloPerformer : Performer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public SoloPerformer(string country, string firstName, string lastName, string birthDate) //
            : base(country)
        {
            FirstName = firstName;
            LastName = lastName;

            if (!DateTime.TryParse(birthDate, out DateTime parsedDate))
                throw new ArgumentException("Неверный формат даты рождения");

            BirthDate = parsedDate;
        }

        
        public override string[] GetInfo()
        {
            return new string[]
            {
                $"{FirstName} {LastName}",
                $"Страна: {Country}. Дата рождения: {BirthDate:d}."
            };
        }
    }
}