using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmersParadise.Models.FarmManager
{
    public class Barn
    {
        private int barnId;

        public int BarnId
        {
            get { return barnId; }
            set { barnId = value; }
        }

        private string barnName;

        public string BarnName
        {
            get { return barnName; }
            set { barnName = value; }
        }

        public Farm Farm { get; set; }

        public ICollection<Box> Boxes { get; set; }

        public Barn(string barnName)
        {
            BarnName = barnName;
        }
    }
}