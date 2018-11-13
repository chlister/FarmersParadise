using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FarmersParadise.Models;
using FarmersParadise.Models.SensorManager;

namespace FarmersParadise.Controllers.API
{
    public class TemperatureSensorController : ApiController
    {
        private FarmerContext _ctx;

        public TemperatureSensorController()
        {
            _ctx = new FarmerContext();
        }

        // GET api/TemperatureSensor
        [HttpGet]
        public IHttpActionResult Get()
        {
            var TempList = _ctx.TemperatureSensors.ToList();

            return Ok(TempList);
        }

        // GET api/TemperatureSensor/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var Temp = _ctx.TemperatureSensors.Where(t => t.SensorId == id).SingleOrDefault();

            if (Temp != null)
            {
                var returnValue = "";
                try { 
                returnValue = SensorLib.SensorLib.ReadwithMAC(Temp.MacAddress);
                }
                catch(Exception e)
                {
                    Ok(e.Message);
                }
                
                return Ok(returnValue);
            }
            return BadRequest();
        }

        // POST: api/TemperatureSensor
        [HttpPost]
        public IHttpActionResult Post(TemperatureSensor temp)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _ctx.TemperatureSensors.Add(temp);
            _ctx.SaveChanges();
            return Created("Added to Db", temp);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}