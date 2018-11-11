using FarmersParadise.Models;
using FarmersParadise.Models.FarmManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FarmersParadise.Controllers.API
{
    public class BoxController : ApiController
    {
        private FarmerContext _ctx;

        public BoxController()
        {
            _ctx = new FarmerContext();
        }

        // GET: api/Boxes
        [HttpGet]
        public IHttpActionResult Get()
        {
            var boxes = _ctx.Boxes.ToList();
            return Ok(boxes);

        }

        // GET: api/Boxes/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var dbBox = _ctx.Boxes.Where(b => b.BoxId == id).SingleOrDefault();
            if (dbBox == null)
                return BadRequest();

            return Ok(dbBox);

        }

        // POST: api/Boxes
        [HttpPost]
        public IHttpActionResult Post(Box box)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _ctx.Boxes.Add(box);
            var boxInDb = _ctx.Boxes.Find(box);
            //context.SaveChanges();
            return Created("", boxInDb);

        }

        // PUT: api/Boxes/5
        [HttpPut]
        public IHttpActionResult Put(int id, Box box)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var dbBox = _ctx.Boxes.Where(b => b.BoxId == id).SingleOrDefault();

            if (dbBox == null)
                return NotFound();

            dbBox.BoxType = box.BoxType;
            dbBox.Pigs = box.Pigs;
            dbBox.BoxName = box.BoxName;
            dbBox.Barn = box.Barn;
            //context.SaveChanges();

            return Ok();

        }

        // DELETE: api/Boxes/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var dbBox = _ctx.Boxes.Where(b => b.BoxId == id).SingleOrDefault();
            if (dbBox == null)
                return BadRequest();
            _ctx.Boxes.Remove(dbBox);
            //context.SaveChanges();

            return Ok();

        }
    }
}
