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
        // GET: api/Farm
        [HttpGet]
        public IHttpActionResult GetFarms()
        {
            using (var context = new FarmerContext())
            {
                var farms = context.Farms.ToList();

                return Ok(farms);
            }
        }

        // GET: api/Farm/5
        [HttpGet]
        public IHttpActionResult GetFarm(int id)
        {
            using (var context = new FarmerContext())
            {
                var farm = from farms in context.Farms
                           where farms.FarmId == id
                           select farms;

                return Ok(farm);
            }
        }

        // POST: api/Farm
        [HttpPost]
        public IHttpActionResult PostFarm(Farm farm)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            using (var context = new FarmerContext())
            {

                var newFarm = new Farm();
                if (farm.FarmName != null)
                {
                    newFarm = farm;
                    context.Farms.Add(newFarm);
                    //context.SaveChanges();

                    return Created("Added to Db", newFarm);
                }
                return BadRequest();
            }
        }

        // PUT: api/Farm/5
        [HttpPut]
        public IHttpActionResult Put(int id, Farm farm)
        {
            if (!ModelState.IsValid)
            {
                using (var context = new FarmerContext())
                {
                    var DbFarm = context.Farms.Where(f => f.FarmId == id).SingleOrDefault();
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
            }
            return BadRequest();
        }

        // DELETE: api/Farm/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                using (var context = new FarmerContext())
                {
                    var DbFarm = context.Farms.Where(f => f.FarmId == id).SingleOrDefault();
                    if (DbFarm != null)
                    {
                        context.Farms.Remove(DbFarm);
                        //context.SaveChanges();
                        return Ok();
                    }
                    return BadRequest();
                }
            }
            return BadRequest();
        }
    }
}
