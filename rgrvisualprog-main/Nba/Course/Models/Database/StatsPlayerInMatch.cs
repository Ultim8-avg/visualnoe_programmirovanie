using System;
using System.Collections.Generic;

namespace Course
{
    public partial class StatsPlayerInMatch
    {
        public StatsPlayerInMatch()
        {
            Players = new HashSet<Player>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Team { get; set; }
        public string? Pos { get; set; }
        public double? Age { get; set; }
        public double? Gp { get; set; }
        public float? Mpg { get; set; }
        public float? Min { get; set; }
        public float? Usg { get; set; }
        public float? To { get; set; }
        public float? Fta { get; set; }
        public float? Ft { get; set; }
        public long? MatchId { get; set; }

        public virtual Match? Match { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
