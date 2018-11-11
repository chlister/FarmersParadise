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
        // GET: api/Barn
        [HttpGet]
        public IHttpActionResult Get()
        {
            using (var context = new FarmerContext())
            {
                var barnList = context.Barns.ToList();

                return Ok(barnList);
            }
        }

        // GET: api/Barn/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            using (var context = new FarmerContext())
            {
                var barn = context.Barns.Where(b => b.BarnId == id).SingleOrDefault();

                if (barn != null)
                {
                    return Ok(barn);
                }
                return BadRequest();
            }
        }

        // POST: api/Barn
        [HttpPost]
        public IHttpActionResult Post(Barn barn)
        {
            if (!ModelState.IsValid) // ModelState is when the JSON object is bound to the Barn object
            {
                using (var context = new FarmerContext())
                {
                    context.Barns.Add(barn);
                    //context.SaveChanges();
                    return Created("Created barn: ", barn);
                }
            }
            return BadRequest();
        }

        // PUT: api/Barn/5
        [HttpPut]
        public IHttpActionResult Put(int id, Barn barn)
        {
            if (!ModelState.IsValid)
            {
                using (var context = new FarmerContext())
                {
                    var dbBarn = context.Barns.Where(b => b.BarnId == barn.BarnId).SingleOrDefault();
                    if (dbBarn != null)
                    {
                        dbBarn.BarnName = barn.BarnName;
                        dbBarn.Boxes = barn.Boxes;
                        //context.SaveChanges();
                        return Ok();
                    }
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        // DELETE: api/Barn/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            using (var context = new FarmerContext())
            {
                var dbBarn = context.Barns.Where(b => b.BarnId == id).SingleOrDefault();
                if (dbBarn == null)
                    return BadRequest();
                context.Barns.Remove(dbBarn);
                //context.SaveChanges();
                return Ok();
            }
        }
    }
}
