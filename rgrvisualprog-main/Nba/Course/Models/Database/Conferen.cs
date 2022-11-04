using System;
using System.Collections.Generic;

namespace Course
{
    public partial class Conferen
    {
        public Conferen()
        {
            Divisions = new HashSet<Division>();
        }

        public string? East { get; set; }
        public string? West { get; set; }
        public long Id { get; set; }

        public virtual ICollection<Division> Divisions { get; set; }
    }
}
