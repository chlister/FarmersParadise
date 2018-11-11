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
    public class BarnController : ApiController
    {
        private FarmerContext _ctx;

        public BarnController()
        {
            _ctx = new FarmerContext();
        }
        // GET: api/Barn
        [HttpGet]
        public IHttpActionResult Get()
        {
            var barnList = _ctx.Barns.ToList();

            return Ok(barnList);

        }

        // GET: api/Barn/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var barn = _ctx.Barns.Where(b => b.BarnId == id).SingleOrDefault();

            if (barn != null)
            {
                return Ok(barn);
            }
            return BadRequest();

        }

        // POST: api/Barn
        [HttpPost]
        public IHttpActionResult Post(Barn barn)
        {
            if (!ModelState.IsValid) // ModelState is when the JSON object is bound to the Barn object
            {
                _ctx.Barns.Add(barn);
                //context.SaveChanges();
                return Created("Created barn: ", barn);

            }
            return BadRequest();
        }

        // PUT: api/Barn/5
        [HttpPut]
        public IHttpActionResult Put(int id, Barn barn)
        {
            if (!ModelState.IsValid)
            {
                var dbBarn = _ctx.Barns.Where(b => b.BarnId == barn.BarnId).SingleOrDefault();
                if (dbBarn != null)
                {
                    dbBarn.BarnName = barn.BarnName;
                    dbBarn.Boxes = barn.Boxes;
                    //context.SaveChanges();
                    return Ok();
                }
                return BadRequest();

            }
            return BadRequest();
        }

        // DELETE: api/Barn/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var dbBarn = _ctx.Barns.Where(b => b.BarnId == id).SingleOrDefault();
            if (dbBarn == null)
                return BadRequest();
            _ctx.Barns.Remove(dbBarn);
            //context.SaveChanges();
            return Ok();

        }
    }
}
