using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FarmersParadise.Models.PigManager;

namespace FarmersParadise.Models.FarmManager
{
    public class Box
    {
        public int BoxId { get; set; }
        public string BoxName { get; set; }
        [EnumDataType(typeof(BoxType))]
        [Required]
        public BoxType BoxType { get; set; }

        public Box()
        {
            Pigs = new HashSet<Pig>();
        }

        // Foreign keys
        [Required]
        public int BarnId { get; set; }
        public Barn Barn { get; set; }

        public ICollection<Pig> Pigs { get; set; }

    }
}