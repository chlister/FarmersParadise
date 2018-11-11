using FarmersParadise.Models;
using FarmersParadise.Models.PigManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FarmersParadise.Controllers.API
{
    public class PigController : ApiController
    {
        // GET: api/Pig
        [HttpGet]
        public IHttpActionResult GetAllPigs()
        {
            using (var context = new FarmerContext())
            {
                var pigs = context.Pigs.ToList();
                return Ok(pigs);
            }
        }

        // GET: api/PigsWithoutBox
        /// <summary>
        /// Gets all pigs that is not associated with a box
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Pigs/PigsWithoutBox")]
        public IHttpActionResult PigsWithoutBox()
        {
            using (var context = new FarmerContext())
            {
                var pigs = context.Pigs.Where(p => p.Box == null).ToList(); // If box property is null the pig is homeless
                return Ok(pigs);
            }
        }

        // GET: api/Pig/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            using (var context = new FarmerContext())
            {
                var dbPig = context.Pigs.Where(p => p.PigId == id).SingleOrDefault();
                if (dbPig == null)
                    return BadRequest();

                return Ok(dbPig);
            }
        }

        // POST: api/Pig
        [HttpPost]
        public IHttpActionResult Post(Pig pig)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            using (var context = new FarmerContext())
            {
                context.Pigs.Add(pig);
                //context.SaveChanges();
                return Ok();
            }
        }

        // PUT: api/Pig/5
        [HttpPut]
        public IHttpActionResult Put(int id, Pig pig)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            using (var context = new FarmerContext())
            {
                var dbPig = context.Pigs.Where(p => p.PigId == id).SingleOrDefault();

                if (dbPig == null)
                    return NotFound();

                dbPig.Box = pig.Box;
                //context.SaveChanges();

                return Ok();
            }
        }

        // DELETE: api/Pig/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            using (var context = new FarmerContext())
            {
                var dbPig = context.Pigs.Where(p => p.PigId == id).SingleOrDefault();
                if (dbPig == null)
                    return BadRequest();

                context.Pigs.Remove(dbPig);
                //context.SaveChanges();

                return Ok();
            }
        }
    }
}
