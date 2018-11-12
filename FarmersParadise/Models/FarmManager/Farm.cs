using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmersParadise.Models.FarmManager
{

    public class Farm
    {
        public int FarmId { get; set; }

        public string FarmName { get; set; }

        public virtual ICollection<Barn> Barns { get; set; }

        public Farm()
        {
            Barns = new HashSet<Barn>();
        }
        public Farm(string farmName)
        {
            FarmName = farmName;
        }
    }
}