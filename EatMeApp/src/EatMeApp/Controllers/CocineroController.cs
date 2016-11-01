using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EatMeApp.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EatMeApp.Controllers
{
    [Route("api/[controller]")]
    public class CocineroController : Controller
    {

        public readonly AppDbContext _context;
        public CocineroController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Cooker cooker)
        {
            try
            {
                _context.Cocineros.Add(cooker);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Cooker cooker)
        {
            try
            {
                var cocinero = _context.Cocineros.SingleOrDefault(x => x.CocineroId == id);
                if (cocinero != null)
                {
                    cocinero = cooker;
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                throw;
            }



        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            try
            {
                var cocinero =_context.Cocineros.SingleOrDefault(x => x.CocineroId == id);
                if (cocinero != null)
                {
                    _context.Cocineros.Remove(cocinero);
                    _context.SaveChanges();
                }
                
            }
            catch (Exception ex)
            {

                throw;
            }


        }
    }
}
