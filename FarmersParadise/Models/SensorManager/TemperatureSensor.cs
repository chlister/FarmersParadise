using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmersParadise.Models.FarmManager;

namespace FarmersParadise.Models.SensorManager
{
    public class TemperatureSensor : Sensor, IBarnSensor
    {
        public Barn Barn { get; set; }
    }
}