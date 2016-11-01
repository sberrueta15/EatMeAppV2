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
        public Cocinero Get(int id)
        {
            //Cooker cocinero = new Models.Cooker();
            //cocinero.Nombre = "Rodrigo";
            //cocinero.Apellido = "Suarez";
            //cocinero.Cedula = "4.312.245-7";
            //cocinero.Direccion = "Manuel Albo 2132";
            //cocinero.Mail = "srzsoftware@gmail.com";
            //cocinero.Telefono = "099223445";


            //_context.Cocineros.Add(cocinero);
            //_context.SaveChanges();


            var cocinero = _context.Cocineros.SingleOrDefault(x => x.CocineroId == id);

            return cocinero;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Cocinero cooker)
        {
            try
            {

                Cocinero cocinero = new Models.Cocinero();
                cocinero.Nombre = "Rodrigo";
                cocinero.Apellido = "Suarez";
                cocinero.Cedula = "4.312.245-7";
                cocinero.Direccion = "Manuel Albo 2132";
                cocinero.Mail = "srzsoftware@gmail.com";
                cocinero.Telefono = "099223445";


                _context.Cocineros.Add(cocinero);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Cocinero cooker)
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
