using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmersParadise.Models.FarmManager
{
    
    public class Farm
    {
        private int farmId;

        public int FarmId
        {
            get { return farmId; }
            set { farmId = value; }
        }

        private string farmName;

        public string FarmName
        {
            get { return farmName; }
            set { farmName = value; }
        }

        public virtual ICollection<Barn> Barns { get; set; }

        public Farm(){}
        public Farm(string farmName)
        {
            FarmName = farmName;
        }
    }
}