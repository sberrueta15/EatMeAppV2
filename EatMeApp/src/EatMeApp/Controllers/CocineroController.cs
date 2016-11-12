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
    public class CookerController : Controller
    {

        public readonly AppDbContext _context;
        public CookerController(AppDbContext context)
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
        public Cooker Get(int id)
        {
            var token = Request.Headers["Authorization"].ToString();
            if (!string.IsNullOrWhiteSpace(token))
            {
                token = token.Substring(7);
                if (Authorizer.HasAccess(token, _context))
                {
                    var cooker = _context.Cookers.SingleOrDefault(x => x.Id == id);

                    return cooker;
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
                    var events = _context.Events.Where(x => x.Cooker.Id == id).ToList();

                    return events;
                }
            }
            return null;
        }

        // POST api/values
        [HttpPost]
        [AllowAnonymous]
        public void Post([FromBody]Cooker cooker)
        {
            if (!Exists(cooker))
            {
                //var token = Request.Headers["Authorization"].ToString();
                //if (Authorizer.HasAccess(token, _context))
                //{
                    try
                    {
                        var maxId = _context.Cookers.Max(x => x.Id);

                        int id = maxId + 1;

                        cooker.Id = id;

                        _context.Cookers.Add(cooker);
                        _context.SaveChanges();

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                //}
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Cooker cooker)
        {
            if (!Exists(cooker))
            {
                var token = Request.Headers["Authorization"].ToString();
                if (!string.IsNullOrWhiteSpace(token))
                {
                    token = token.Substring(7);
                    if (Authorizer.HasAccess(token, _context))
                    {
                        try
                        {
                            var cook = _context.Cookers.SingleOrDefault(x => x.Id == id);
                            if (cook != null)
                            {
                                cook.FirstName = cooker.FirstName;
                                cook.LastName = cooker.LastName;
                                cook.Address = cooker.Address;
                                cook.Bio = cooker.Bio;
                                cook.EmailAddress = cooker.EmailAddress;
                                cook.IdentityCard = cooker.IdentityCard;
                                cook.Password = cooker.Password;
                                cook.PostalCode = cooker.PostalCode;
                                cook.Username = cooker.Username;
                                cook.Phone = cooker.Phone;

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
                        var cook = _context.Cookers.SingleOrDefault(x => x.Id == id);
                        if (cook != null)
                        {
                            _context.Cookers.Remove(cook);
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

        private bool Exists(User user)
        {
            var dbUsers = _context.Cookers.Select(x => x.Username == user.Username);
            if (dbUsers.Count() > 1)
            {
                return true;
            }
            return false;
        }
    }
}
