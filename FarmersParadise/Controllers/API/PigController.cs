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
        private FarmerContext _ctx;

        public PigController()
        {
            _ctx = new FarmerContext();
        }

        // GET: api/Pig
        [HttpGet]
        public IHttpActionResult GetAllPigs()
        {
            var pigs = _ctx.Pigs.ToList();
            return Ok(pigs);

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
            var pigs = _ctx.Pigs.Where(p => p.Box == null).ToList(); // If box property is null the pig is homeless
            return Ok(pigs);
        }

        // GET: api/Pig/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var dbPig = _ctx.Pigs.Where(p => p.PigId == id).SingleOrDefault();
            if (dbPig == null)
                return BadRequest();

            return Ok(dbPig);

        }

        // POST: api/Pig
        [HttpPost]
        public IHttpActionResult Post(Pig pig)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _ctx.Pigs.Add(pig);
            _ctx.SaveChanges();
            return Created("Added to Db", pig);

        }

        // PUT: api/Pig/5
        [HttpPut]
        public IHttpActionResult Put(int id, Pig pig)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var dbPig = _ctx.Pigs.Where(p => p.PigId == id).SingleOrDefault();

            if (dbPig == null)
                return NotFound();

            dbPig.Box = pig.Box;
            _ctx.SaveChanges();

            return Ok();

        }

        // DELETE: api/Pig/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var dbPig = _ctx.Pigs.Where(p => p.PigId == id).SingleOrDefault();
            if (dbPig == null)
                return BadRequest();

            _ctx.Pigs.Remove(dbPig);
            _ctx.SaveChanges();

            return Ok();

        }
    }
}
