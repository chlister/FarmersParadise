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
    public class BoxesController : ApiController
    {
        // GET: api/Boxes
        [HttpGet]
        public IHttpActionResult Get()
        {
            using (var context = new FarmerContext())
            {
                var boxes = context.Boxes.ToList();
                return Ok(boxes);
            }
        }

        // GET: api/Boxes/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            using (var context = new FarmerContext())
            {
                var dbBox = context.Boxes.Where(b => b.BoxId == id).SingleOrDefault();
                if (dbBox == null)
                    return BadRequest();

                return Ok(dbBox);
            }
        }

        // POST: api/Boxes
        [HttpPost]
        public IHttpActionResult Post(Box box)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            using (var context = new FarmerContext())
            {
                context.Boxes.Add(box);
                context.SaveChanges();
                return Ok();
            }
        }

        // PUT: api/Boxes/5
        [HttpPut]
        public IHttpActionResult Put(int id, Box box)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            using (var context = new FarmerContext())
            {
                var dbBox = context.Boxes.Where(b => b.BoxId == id).SingleOrDefault();

                if (dbBox == null)
                    return NotFound();

                dbBox.BoxType = box.BoxType;
                dbBox.Pigs = box.Pigs;
                dbBox.BoxName = box.BoxName;
                dbBox.Barn = box.Barn;
                return Ok();
            }
        }

        // DELETE: api/Boxes/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            using (var context = new FarmerContext())
            {
                var dbBox = context.Boxes.Where(b => b.BoxId == id).SingleOrDefault();
                if (dbBox == null)
                    return BadRequest();
                context.Boxes.Remove(dbBox);

                return Ok();
            }
        }
    }
}
