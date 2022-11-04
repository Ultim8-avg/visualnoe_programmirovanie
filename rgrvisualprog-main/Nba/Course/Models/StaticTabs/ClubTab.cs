using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Course.Models.Database;


namespace Course.Models.StaticTabs
{
    public class ClubTab : StaticTab
    {
        public ClubTab(string h = "", DbSet<Club>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("ID");
            DataColumns.Add("Name");
            DataColumns.Add("ManagerID");
            DataColumns.Add("PresidentID");
            DataColumns.Add("Players");
            DataColumns.Add("City");
            DataColumns.Add("Division");
            DataColumns.Add("CityID");
            DataColumns.Add("DivisionID");
            DataColumns.Add("PlayerID");
            DataColumns.Add("StatsMatchID");
            ObjectList = DBS.ToList<object>();
        }

        new public DbSet<Club>? DBS { get; set; }
    }
}
