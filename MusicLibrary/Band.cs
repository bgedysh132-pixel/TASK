using System;

namespace MusicLibrary
{
    public class Band : Performer
    {
        public string Name { get; set; }
        public string[] Members { get; set; }
        public int FormationYear { get; set; }

        public Band(string country, string name, string[] members, int formationYear)
            : base(country)
        {
            Name = name;
            Members = members;
            FormationYear = formationYear;

            if (formationYear > DateTime.Now.Year || formationYear < 1800)
                throw new ArgumentException("Некорректный год образования группы.");
        }

        
        public override string[] GetInfo()
        {
            string membersList = Members != null ? string.Join(", ", Members) : "Неизвестен";

            return new string[]
            {
                Name,
                $"Страна: {Country}. Год образования: {FormationYear}. Состав: {membersList}."
            };
        }
    }
}