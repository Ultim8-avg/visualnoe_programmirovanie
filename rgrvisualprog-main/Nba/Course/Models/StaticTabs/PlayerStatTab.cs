using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Course.Models.Database;

namespace Course.Models.StaticTabs
{
    public class PlayerStatTab : StaticTab
    {
        public PlayerStatTab(string h = "", DbSet<Player>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("Id");
            DataColumns.Add("Name");
            DataColumns.Add("DateOfBirth");
            DataColumns.Add("Height");
            DataColumns.Add("Weight");
            DataColumns.Add("HighSchool");
            DataColumns.Add("Colleges");
            DataColumns.Add("University");
            DataColumns.Add("Club");
            DataColumns.Add("StatsPlayerInMatchId");
            ObjectList = DBS.ToList<object>();
        }

        new public DbSet<Player>? DBS { get; set; }
    }
}
