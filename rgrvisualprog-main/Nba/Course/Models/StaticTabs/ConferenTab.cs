using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Course.Models.Database;


namespace Course.Models.StaticTabs
{
    public class ConferenTab : StaticTab
    {
        public ConferenTab(string h = "", DbSet<Conferen>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("ID");
            DataColumns.Add("East");
            DataColumns.Add("West");
            ObjectList = DBS.ToList<object>();
        }

        new public DbSet<Conferen>? DBS { get; set; }
    }
}
