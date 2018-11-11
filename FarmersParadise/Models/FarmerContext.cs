using FarmersParadise.Models.FarmManager;
using FarmersParadise.Models.PigManager;
using FarmersParadise.Models.SensorManager;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FarmersParadise.Models
{
    public class FarmerContext : DbContext
    {
        public FarmerContext(): base()
        {

        }

        // Db sets here
        public DbSet<Farm> Farms { get; set; }
        public DbSet<Barn> Barns { get; set; }
        public DbSet<Box> Boxes { get; set; }
        //public DbSet<BoxType> BoxTypes { get; set; } //Marc vil gerne have den står der
        public DbSet<Pig> Pigs { get; set; }
        public DbSet<TemperatureSensor> TemperatureSensors { get; set; }
    }
}