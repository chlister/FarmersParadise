using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmersParadise.Models.FarmManager
{
    public class Barn
    {
        public int BarnId { get; set; }
        public string BarnName { get; set; }

        [Required]
        public int FarmId { get; set; }
        public Farm Farm { get; set; }

        public ICollection<Box> Boxes { get; set; }

        public Barn(string barnName)
        {
            BarnName = barnName;
        }

        public Barn()
        {
        }
    }
}