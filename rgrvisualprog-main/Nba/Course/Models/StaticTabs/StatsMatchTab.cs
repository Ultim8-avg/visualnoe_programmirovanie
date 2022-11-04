using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Course.Models.Database;


namespace Course.Models.StaticTabs
{
    public class StatsMatchTab : StaticTab
    {
        public StatsMatchTab(string h = "", DbSet<StatsMatch>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("Id");
            DataColumns.Add("Club");
            DataColumns.Add("Conf");
            DataColumns.Add("Division");
            DataColumns.Add("Gp");
            DataColumns.Add("PtsGm");
            DataColumns.Add("APtsGm");
            DataColumns.Add("PtsDiff");
            DataColumns.Add("Pace");
            DataColumns.Add("Oeff");
            DataColumns.Add("Deff");
            DataColumns.Add("Ediff");
            DataColumns.Add("Sos");
            DataColumns.Add("RSos");
            DataColumns.Add("Sar");
            DataColumns.Add("Cons");
            DataColumns.Add("A4f");
            DataColumns.Add("W");
            DataColumns.Add("L");
            DataColumns.Add("Win");
            ObjectList = DBS.ToList<object>();
        }

        new public DbSet<StatsMatch>? DBS { get; set; }
    }
}
