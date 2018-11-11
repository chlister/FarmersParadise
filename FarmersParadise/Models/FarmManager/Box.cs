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
        public virtual Barn Barn { get; set; }
        public virtual ICollection<Pig> Pigs { get; set; }
    }
}