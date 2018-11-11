using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FarmersParadise.Models;
using FarmersParadise.Models.FarmManager;

namespace FarmersParadise.Controllers.API
{
    public class FarmController : ApiController
    {
        private FarmerContext _ctx;

        public FarmController()
        {
            _ctx = new FarmerContext();
        }

        // GET: api/Farm
        [HttpGet]
        public IHttpActionResult GetFarms()
        {
            var farm = _ctx.Farms.ToList();
            return Ok(farm);
        }

        // GET: api/Farm/5
        [HttpGet]
        public IHttpActionResult GetFarm(int id)
        {
            var farm = from farms in _ctx.Farms
                       where farms.FarmId == id
                       select farms;

            return Ok(farm);
        }


        // POST: api/Farm
        [HttpPost]
        public IHttpActionResult PostFarm(Farm farm)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var newFarm = new Farm();
            if (farm.FarmName != null)
            {
                newFarm = farm;
                _ctx.Farms.Add(newFarm);
                //context.SaveChanges();

                return Created("Added to Db", newFarm);
            }
            return BadRequest();

        }

        // PUT: api/Farm/5
        [HttpPut]
        public IHttpActionResult Put(int id, Farm farm)
        {
            if (!ModelState.IsValid)
            {
                var DbFarm = _ctx.Farms.Where(f => f.FarmId == id).SingleOrDefault();
                if (DbFarm != null)
                {
                    // We should talk about how we update here
                    DbFarm.FarmName = farm.FarmName;
                    DbFarm.Barns = farm.Barns;
                    //context.SaveChanges();
                    return Ok();
                }
                return BadRequest();
            }
            return BadRequest();
        }

        // DELETE: api/Farm/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                var DbFarm = _ctx.Farms.Where(f => f.FarmId == id).SingleOrDefault();
                if (DbFarm != null)
                {
                    _ctx.Farms.Remove(DbFarm);
                    //context.SaveChanges();
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
