using System;
using System.Collections.Generic;

namespace Course
{
    public partial class Player
    {
        public Player()
        {
            Clubs = new HashSet<Club>();
            Matches = new HashSet<Match>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public string? DateOfBirth { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }
        public string? HighSchool { get; set; }
        public string? Colleges { get; set; }
        public string? University { get; set; }
        public long? ClubId { get; set; }
        public long? StatsPlayerInMatchId { get; set; }

        public virtual StatsPlayerInMatch? StatsPlayerInMatch { get; set; }
        public virtual ICollection<Club> Clubs { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}
