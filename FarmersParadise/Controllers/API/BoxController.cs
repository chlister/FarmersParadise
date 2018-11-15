using FarmersParadise.Models;
using FarmersParadise.Models.FarmManager;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        // GET: api/Box
        [HttpGet]
        public IHttpActionResult Get()
        {
            var boxes = _ctx.Boxes.ToList();
            return Ok(boxes);

        }

        // GET: api/Box/BoxWithBarn
        [HttpGet]
        [Route("api/Box/BoxWithBarn")]
        public IHttpActionResult BoxWithBarn()
        {
            var boxes = _ctx.Boxes.Include(i => i.Barn).ToList();
            for(int i = 0; i < boxes.Count(); i++)
            {
                boxes[i].BoxName = boxes[i].BoxName + "(Barn: " + boxes[i].Barn.BarnName + ")";
                boxes[i].Barn = null;
            }
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

        [HttpPost]
        [Route("api/Box/BoxFromBarn")]
        public IHttpActionResult BoxFromBarn(Barn barn)
        {
            if (ModelState.IsValid) // ModelState is when the JSON object is bound to the Barn object
            {
                var boxes = _ctx.Boxes.Where(p => p.Barn.BarnId == barn.BarnId).ToList();
                return Ok(boxes);
            }
            return BadRequest();
        }

        // POST: api/Boxes
        [HttpPost]
        public IHttpActionResult Post(Box box)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Box ba = new Box(box.BoxName);
            _ctx.Barns.Where(f => f.BarnId == box.Barn.BarnId).Include(b => b.Boxes).SingleOrDefault().Boxes.Add(ba);
            //_ctx.Barns.Add(barn);
            _ctx.SaveChanges();
            return Created("Created box: ", box);

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
            _ctx.SaveChanges();

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
            _ctx.SaveChanges();

            return Ok();

        }
    }
}
