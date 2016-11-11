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

                var listaEventCommensal = _context.EventCommnesals.Where(x => x.EventId == id).ToList();

                List<Commensal> listaDeCommensales = new List<Models.Commensal>();
                if (listaEventCommensal != null)
                {
                    foreach (var item in listaEventCommensal)
                    {
                        var commensal = _context.Commnesals.SingleOrDefault(x => x.Id == item.CommensalId);
                        if (commensal != null)
                        {
                            listaDeCommensales.Add(commensal);
                        }
                    }
                }

                if (listaDeCommensales.Count > 0)
                {
                    evento.Commensals = listaDeCommensales;
                }

                return evento;
            }
            catch (Exception ex )
            {

                throw ex;
            }

        }

        // POST api/values
        [HttpPost("{idCooker}")]
        public void Post(int idCooker,[FromBody]Event evento)
        {
            try
            {
                var maxId = _context.Events.Max(x => x.Id);

                int id = maxId + 1;


                var cooker = _context.Cookers.SingleOrDefault(x => x.Id == idCooker);

                if (cooker == null)
                {
                    return;
                }

                evento.Cooker = cooker;
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
                    eventt.LocationX = value.LocationX;
                    eventt.LocationY = value.LocationY;
                    eventt.SoldTickets = value.SoldTickets;
                    eventt.TicketPrice = value.TicketPrice;
                    eventt.Title = value.Title;
                    eventt.TotalTickets = value.TotalTickets;
                    eventt.Description = value.Description;
                    eventt.FoodType = value.FoodType;

                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // PUT api/values/5
        [HttpPut("asignarcomensal/{idCommensal}/{idEvento}")]
        public void AsignarCommensalAEvento(int idCommensal, int idEvento)
        {
            try
            {
                var eventt = _context.Events.SingleOrDefault(x => x.Id == idEvento);
                if (eventt != null)
                {
                    eventt.SoldTickets = eventt.SoldTickets + 1;

                    var maxId = _context.EventCommnesals.Max(x => x.Id);

                    var eventCommensalId = maxId + 1;

                    EventCommensal eventCommensal = new Models.EventCommensal();
                    eventCommensal.Id = eventCommensalId;
                    eventCommensal.CommensalId = idCommensal;
                    eventCommensal.EventId = idEvento;

                    _context.EventCommnesals.Add(eventCommensal);
                    _context.SaveChanges();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        // PUT api/values/5
        [HttpPut("desasignarcomensal/{idCommensal}/{idEvento}")]
        public void DesasignarCommensalAEvento(int idCommensal, int idEvento)
        {
            try
            {
                var eventt = _context.Events.SingleOrDefault(x => x.Id == idEvento);
                if (eventt != null)
                {
                    eventt.SoldTickets = eventt.SoldTickets - 1;

                    var eventCommensal = _context.EventCommnesals.SingleOrDefault(x => x.EventId == idEvento && x.CommensalId == idCommensal);
                    if (eventCommensal != null)
                    {
                        _context.EventCommnesals.Remove(eventCommensal);
                        _context.SaveChanges();
                    }
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
