using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Course.Models.Database;


namespace Course.Models.StaticTabs
{
    public class CityTab : StaticTab
    {
        public CityTab(string h = "", DbSet<City>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("ID");
            DataColumns.Add("Name");
            DataColumns.Add("Clubs");
            DataColumns.Add("State");
            ObjectList = DBS.ToList<object>();
        }

        new public DbSet<City>? DBS { get; set; }
    }
}
