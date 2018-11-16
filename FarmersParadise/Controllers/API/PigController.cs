using FarmersParadise.Models;
using FarmersParadise.Models.FarmManager;
using FarmersParadise.Models.PigManager;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        [HttpPost]
        [Route("api/Pig/PigsFromBox")]
        public IHttpActionResult PigsFromBox(Box box)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var pigs = _ctx.Pigs.Where(p => p.Box.BoxId == box.BoxId).ToList(); // If box property is null the pig is homeless
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
            var pigs = _ctx.Pigs.Include(i => i.Box).Where(p => p.Box == null).ToList(); // If box property is null the pig is homeless
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
        public IHttpActionResult Put(int id, Box box)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var dbPig = _ctx.Pigs.Where(p => p.PigId == id).SingleOrDefault();

            if (dbPig == null)
                return NotFound();
            Pig npig = new Pig();
            npig.Box = dbPig.Box;
            npig.CHRTag = dbPig.CHRTag;
            npig.PigId = dbPig.PigId;
            npig.PigType = dbPig.PigType;

            if (dbPig.Box != null)
            {
                _ctx.Boxes.Where(f => f.BoxId == dbPig.Box.BoxId).Include(b => b.Pigs).SingleOrDefault().Pigs.Remove(dbPig);
                _ctx.Boxes.Where(f => f.BoxId == box.BoxId).Include(b => b.Pigs).SingleOrDefault().Pigs.Add(npig);
            }
            else
            {
                _ctx.Pigs.Remove(dbPig);
                _ctx.Boxes.Where(f => f.BoxId == box.BoxId).Include(b => b.Pigs).SingleOrDefault().Pigs.Add(npig);
            }
            _ctx.SaveChanges();

            return Ok(dbPig);

        }

        // PUT: api/Pig/5
        [HttpPut]
        [Route("api/Pig/MovePig")]
        public IHttpActionResult MovePig(int id, Pig pig)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Pig dbPig = new Pig();
            dbPig.CHRTag = pig.CHRTag;
            dbPig.PigId = pig.PigId;
            dbPig.PigType = pig.PigType;

            if (pig.Box != null)
            {
                var olddbPig = _ctx.Pigs.Where(p => p.PigId == pig.PigId).SingleOrDefault();
                _ctx.Boxes.Where(f => f.BoxId == olddbPig.Box.BoxId).Include(b => b.Pigs).SingleOrDefault().Pigs.Remove(olddbPig);
                _ctx.Boxes.Where(f => f.BoxId == pig.Box.BoxId).Include(b => b.Pigs).SingleOrDefault().Pigs.Add(dbPig);
                
            }
            else
            {
                dbPig = _ctx.Pigs.Where(p => p.PigId == id).SingleOrDefault();
                _ctx.Boxes.Where(f => f.BoxId == pig.Box.BoxId).Include(b => b.Pigs).SingleOrDefault().Pigs.Add(dbPig);
            }

            if (dbPig == null)
                return NotFound();

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

            return Ok(dbPig);

        }
    }
}
