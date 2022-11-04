using System;
using System.Collections.Generic;

namespace Course
{
    public partial class City
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Clubs { get; set; }
        public string? State { get; set; }
    }
}
