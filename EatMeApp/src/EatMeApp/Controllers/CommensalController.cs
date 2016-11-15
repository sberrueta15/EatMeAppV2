using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EatMeApp.Models;
using EatMeApp.Utilities;
using Microsoft.AspNetCore.Authorization;

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
            // TODO
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Commensal Get(int id)
        {
            var token = Request.Headers["Authorization"].ToString();
                 if (!string.IsNullOrWhiteSpace(token))
            {
                token = token.Substring(7);
                if (Authorizer.HasAccess(token, _context))
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
            }
            return null;
        }

        // GET api/values/5
        [HttpGet("{id}/events")]
        public List<Event> GetEvents(int id)
        {
            var token = Request.Headers["Authorization"].ToString();
            if (!string.IsNullOrWhiteSpace(token))
            {
                token = token.Substring(7);
                if (Authorizer.HasAccess(token, _context))
                {
                    try
                    {

                        var eventsId = _context.EventCommnesals.Where(x => x.CommensalId == id).Select(ev => ev.EventId);
                        
                        var e = _context.Events.Where(x => eventsId.Contains(x.Id)).ToList();
                        
                        return e;

                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }
            return null;
        }


        // POST api/values
        [HttpPost]
        [AllowAnonymous]
        public void Post([FromBody]Commensal commensal)
        {
            //var token = Request.Headers["Authorization"].ToString();
            //if (Authorizer.HasAccess(token, _context))
            //{
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
            //}


        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Commensal commensal)
        {
            var token = Request.Headers["Authorization"].ToString();
            if (!string.IsNullOrWhiteSpace(token))
            {
                token = token.Substring(7);
                if (Authorizer.HasAccess(token, _context))
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
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var token = Request.Headers["Authorization"].ToString();
            if (!string.IsNullOrWhiteSpace(token))
            {
                token = token.Substring(7);
                if (Authorizer.HasAccess(token, _context))
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
    }
}
