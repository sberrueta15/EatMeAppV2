using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EatMeApp.Models
{
    public class Event
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("foodType")]
        public FoodType FoodType { get; set; }

        [JsonProperty("ticketPrice")]
        public double TicketPrice { get; set; }

        [JsonProperty("totalTickets")]
        public int TotalTickets { get; set; }

        [JsonProperty("soldTickets")]
        public int SoldTickets { get; set; }

        [JsonProperty("locationX")]
        public double LocationX { get; set; }

        [JsonProperty("locationY")]
        public double LocationY { get; set; }

        [JsonProperty("startTime")]
        public DateTime startTime { get; set; }

        [JsonProperty("endTime")]
        public DateTime endTime { get; set; }

        [JsonIgnore]
        [JsonProperty("cooker")]
        public Cooker Cooker { get; set; }

        [NotMapped]
        [JsonProperty("commensals")]
        public IEnumerable<Commensal> Commensals { get; set; }
    }

    public enum FoodType
    {
        NoRestriction,
        Vegeterian,
        Vegan,
        Celiac
    }
}
