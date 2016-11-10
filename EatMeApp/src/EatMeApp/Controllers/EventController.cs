using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EatMeApp.Models;
using System.IdentityModel.Tokens.Jwt;
using EatMeApp.Utilities;

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
            var token = Request.Headers["Authorization"].ToString();
            if (Authorizer.HasAccess(token, _context))
            {
                var listaEventos = _context.Events.ToList();
                return listaEventos;
            }
            else
            {
                return null;
            }


        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Event Get(int id)
        {
            var token = Request.Headers["Authorization"].ToString();
            if (Authorizer.HasAccess(token, _context))
            {
                try
                {
                    var evento = _context.Events.SingleOrDefault(x => x.Id == id);

                    return evento;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
                return null;
            }


        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Event evento)
        {
            var token = Request.Headers["Authorization"].ToString();
            if (Authorizer.HasAccess(token, _context))
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
