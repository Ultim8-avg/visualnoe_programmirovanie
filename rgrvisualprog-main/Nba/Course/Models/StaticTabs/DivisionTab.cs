using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Course.Models.Database;


namespace Course.Models.StaticTabs
{
    public class DivisionTab : StaticTab
    {
        public DivisionTab(string h = "", DbSet<Division>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("ID");
            DataColumns.Add("Atlantic");
            DataColumns.Add("Central");
            DataColumns.Add("Northwest");
            DataColumns.Add("Pacific");
            DataColumns.Add("Southwest");
            DataColumns.Add("ConfId");
            ObjectList = DBS.ToList<object>();
        }

        new public DbSet<Division>? DBS { get; set; }
    }
}
