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
        /// <summary>
        /// Gets all barn
        /// No matter farms
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                using (var context = new FarmerContext())
                {
                    var barnList = context.Barns.ToList();

                    return Ok(barnList);
                }
            }
            return BadRequest();
        }

        // GET: api/Barn
        /// <summary>
        /// Gets all barn
        /// Query decides what farm it belongs to
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get(string query = null)
        {
            if (!ModelState.IsValid)
            {
                using (var context = new FarmerContext())
                {
                    if (!String.IsNullOrWhiteSpace(query))
                    {

                    }
                    var barnList = context.Barns.ToList();

                    return Ok(barnList);
                }
            }
            return BadRequest();
        }

        // GET: api/Barn/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            if (!ModelState.IsValid)
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
            return BadRequest();
        }

        // POST: api/Barn
        [HttpPost]
        public IHttpActionResult Post([FromBody]string value)
        {
            if (!ModelState.IsValid)
            {
                using (var context = new FarmerContext())
                {
                    
                }
            }
            return BadRequest();
        }

        // PUT: api/Barn/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            if (!ModelState.IsValid)
            {
                using (var context = new FarmerContext())
                {
                    
                }
            }
            return BadRequest();
        }

        // DELETE: api/Barn/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                using (var context = new FarmerContext())
                {
                    
                }
            }
            return BadRequest();
        }
    }
}
