using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmersParadise.Models.SensorManager
{
    public abstract class Sensor
    {
        [Key]
        public int SensorId { get; set; }
        public string SensorName { get; set; }
        [Required]
        public string MacAddress { get; set; }
    }
}