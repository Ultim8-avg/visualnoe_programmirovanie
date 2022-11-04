using System;
using System.Collections.Generic;

namespace Course
{
    public partial class Division
    {
        public Division()
        {
            Clubs = new HashSet<Club>();
        }

        public long Id { get; set; }
        public string? Atlantic { get; set; }
        public string? Central { get; set; }
        public string? Northwest { get; set; }
        public string? Pacific { get; set; }
        public string? Southwest { get; set; }
        public long? ConfId { get; set; }

        public virtual Conferen? Conf { get; set; }
        public virtual ICollection<Club> Clubs { get; set; }
    }
}
