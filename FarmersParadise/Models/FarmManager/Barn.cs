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

        #region Ctor
        public Barn(string barnName) : base()
        {
            BarnName = barnName;
        }

        public Barn()
        {
            //Boxes = new HashSet<Box>();
        }
        #endregion

        //Foreign Key
        [Required]
        public int FarmId { get; set; }
        public virtual Farm Farm { get; set; }

        public virtual ICollection<Box> Boxes { get; set; }


    }
}