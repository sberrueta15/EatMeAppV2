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
    public class CommensalController : Controller
    {

        public readonly AppDbContext _context;
        public CommensalController(AppDbContext context)
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
        public Commensal Get(int id)
        {
            try
            {

                var commensal = _context.Commnesals.SingleOrDefault(x => x.Id == id);

                return commensal;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Commensal commensal)
        {

            try
            {
                var maxId = _context.Commnesals.Max(x => x.Id);

                maxId = maxId + 1;

                commensal.Id = maxId;

                _context.Commnesals.Add(commensal);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }



        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Commensal commensal)
        {
            try
            {
                var com = _context.Commnesals.SingleOrDefault(x => x.Id == id);
                if (com != null)
                {
                    com.FirstName = commensal.FirstName;
                    com.LastName = commensal.LastName;
                    com.Address = commensal.Address;
                    com.Preferences = commensal.Preferences;
                    com.EmailAddress = commensal.EmailAddress;
                    com.IdentityCard = commensal.IdentityCard;
                    com.Password = commensal.Password;
                    com.PostalCode = commensal.PostalCode;
                    com.Username = commensal.Username;
                    com.Phone = commensal.Phone;
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

            try
            {
                var commensal = _context.Commnesals.SingleOrDefault(x => x.Id == id);
                if (commensal != null)
                {
                    _context.Commnesals.Remove(commensal);
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
