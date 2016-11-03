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
    public class EventController : Controller
    {

        public readonly AppDbContext _context;
        public EventController(AppDbContext context)
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
        public Event Get(int id)
        {
            try
            {
                Event evento = new Models.Event();
                evento.Description = "Descripcion";
                evento.FoodType = FoodType.NoRestriction;
                evento.LocationX = 54.22321;
                evento.LocationY = -23.43252;
                evento.SoldTickets = 40;
                evento.TicketPrice = 250;
                evento.Title = "Test";
                evento.TotalTickets = 500;

                _context.Events.Add(evento);
                _context.SaveChanges();

                return evento;
            }
            catch (Exception ex )
            {

                return null;
            }

        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Event evento)
        {
            try
            {
                var maxId = _context.Events.Max(x => x.Id);

                int id = maxId + 1;

                evento.Id = id;
                
                _context.Events.Add(evento);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            


        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {


        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {


        }
    }
}
