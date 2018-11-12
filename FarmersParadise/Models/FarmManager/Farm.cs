using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmersParadise.Models.FarmManager
{

    public class Farm
    {
        [Key]
        public int FarmId { get; set; }
        public string FarmName { get; set; }

        #region Constructors

        public Farm()
        {
            Barns = new HashSet<Barn>();
        }
        public Farm(string farmName) : base()
        {
            FarmName = farmName;
        }

        #endregion

        // Foreign Key
        
        public virtual ICollection<Barn> Barns { get; set; }

    }
}