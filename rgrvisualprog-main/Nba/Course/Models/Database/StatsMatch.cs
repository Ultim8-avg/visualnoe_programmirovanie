using System;
using System.Collections.Generic;

namespace Course
{
    public partial class StatsMatch
    {
        public StatsMatch()
        {
            Clubs = new HashSet<Club>();
            Matches = new HashSet<Match>();
        }

        public long Id { get; set; }
        public string? Club { get; set; }
        public string? Conf { get; set; }
        public string? Division { get; set; }
        public float? Gp { get; set; }
        public float? PtsGm { get; set; }
        public float? APtsGm { get; set; }
        public float? PtsDiff { get; set; }
        public float? Pace { get; set; }
        public float? Oeff { get; set; }
        public float? Deff { get; set; }
        public float? Ediff { get; set; }
        public float? Sos { get; set; }
        public float? RSos { get; set; }
        public float? Sar { get; set; }
        public float? Cons { get; set; }
        public float? A4f { get; set; }
        public long? W { get; set; }
        public long? L { get; set; }
        public float? Win { get; set; }

        public virtual ICollection<Club> Clubs { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}
