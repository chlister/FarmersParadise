using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmersParadise.Models.PigManager;

namespace FarmersParadise.Models.FarmManager
{
    public class Box
    {
        private int boxId;

        public int BoxId
        {
            get { return boxId; }
            set { boxId = value; }
        }
        private string boxName;

        public string BoxName
        {
            get { return boxName; }
            set { boxName = value; }
        }

        private BoxType boxType;

        public BoxType BoxType
        {
            get { return boxType; }
            set { boxType = value; }
        }

        public Barn Barn { get; set; }

        public ICollection<Pig> Pigs { get; set; }
    } 
}