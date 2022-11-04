using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Course.Models.Database;


namespace Course.Models.StaticTabs
{
    public class StatsPlayerInMatchTab : StaticTab
    {
        public StatsPlayerInMatchTab(string h = "", DbSet<StatsPlayerInMatch>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("ID");
            DataColumns.Add("Name");
            DataColumns.Add("Team");
            DataColumns.Add("Pos");
            DataColumns.Add("Age");
            DataColumns.Add("Gp");
            DataColumns.Add("Mpg");
            DataColumns.Add("Min");
            DataColumns.Add("Usg");
            DataColumns.Add("To");
            DataColumns.Add("Fta");
            DataColumns.Add("Ft");
            DataColumns.Add("MatchId");
            ObjectList = DBS.ToList<object>();
        }

        new public DbSet<StatsPlayerInMatch>? DBS { get; set; }
    }
}
