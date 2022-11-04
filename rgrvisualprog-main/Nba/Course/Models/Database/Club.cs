using System;
using System.Collections.Generic;

namespace Course
{
    public partial class Club
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public long? ManagerId { get; set; }
        public long? PresidentId { get; set; }
        public long? Players { get; set; }
        public string? City { get; set; }
        public string? Division { get; set; }
        public long? CityId { get; set; }
        public long? DivisionId { get; set; }
        public long? PlayerId { get; set; }
        public long? StatsMatchId { get; set; }

        public virtual Division? DivisionNavigation { get; set; }
        public virtual Player? Player { get; set; }
        public virtual StatsMatch? StatsMatch { get; set; }
    }
}
