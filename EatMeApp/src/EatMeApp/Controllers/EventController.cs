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
        public List<Event> Get()
        {

            var listaEventos = _context.Events.ToList();

            return listaEventos;

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Event Get(int id)
        {
            try
            {
                var evento = _context.Events.SingleOrDefault(x => x.Id == id);

                return evento;
            }
            catch (Exception ex )
            {

                throw ex;
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
                throw ex;
            }
            


        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Event value)
        {
            try
            {
                var eventt = _context.Events.SingleOrDefault(x => x.Id == id);
                if (eventt != null)
                {
                    eventt.FirstName = cooker.FirstName;
                    eventt.LastName = cooker.LastName;
                    eventt.Address = cooker.Address;
                    eventt.Bio = cooker.Bio;
                    eventt.EmailAddress = cooker.EmailAddress;
                    eventt.IdentityCard = cooker.IdentityCard;
                    eventt.Password = cooker.Password;
                    eventt.PostalCode = cooker.PostalCode;
                    eventt.Username = cooker.Username;
                    eventt.Phone = cooker.Phone;

                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {


        }
    }
}
