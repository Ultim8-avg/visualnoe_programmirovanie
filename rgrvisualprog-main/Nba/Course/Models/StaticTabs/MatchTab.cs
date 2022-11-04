using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Course.Models.Database;


namespace Course.Models.StaticTabs
{
    public class MatchTab : StaticTab
    {
        public MatchTab(string h = "", DbSet<Match>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("Id");
            DataColumns.Add("Number");
            DataColumns.Add("Teams");
            DataColumns.Add("Date");
            DataColumns.Add("Result");
            DataColumns.Add("StatsMatchId");
            DataColumns.Add("PlayerId");
            ObjectList = DBS.ToList<object>();
        }

        new public DbSet<Match>? DBS { get; set; }
    }
}
