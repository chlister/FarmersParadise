using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmersParadise.Models.PigManager;

namespace FarmersParadise.Models.FarmManager
{
    public class Box
    {
        public int BoxId { get; set; }
        public string BoxName { get; set; }
        public BoxType BoxType { get; set; }
        
        // Foreign keys
        public Barn Barn { get; set; }

        public ICollection<Pig> Pigs { get; set; }

        public Box(string boxName)
        {
            BoxName = boxName;
        }

        public Box()
        {
        }
    }
}