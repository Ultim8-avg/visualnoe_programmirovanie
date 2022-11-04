using System;
using System.Collections.Generic;

namespace Course
{
    public partial class Match
    {
        public Match()
        {
            StatsPlayerInMatches = new HashSet<StatsPlayerInMatch>();
        }

        public long Id { get; set; }
        public long? Number { get; set; }
        public string? Teams { get; set; }
        public string? Date { get; set; }
        public string? Result { get; set; }
        public long? StatsMatchId { get; set; }
        public long? PlayerId { get; set; }

        public virtual Player? Player { get; set; }
        public virtual StatsMatch? StatsMatch { get; set; }
        public virtual ICollection<StatsPlayerInMatch> StatsPlayerInMatches { get; set; }
    }
}
