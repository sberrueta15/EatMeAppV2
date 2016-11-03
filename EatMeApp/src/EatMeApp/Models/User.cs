using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatMeApp.Models
{
    public abstract class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("Id")]
        public int Id { get; set; }

        [Required]
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [Required]
        [JsonProperty("EmailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("Phone")]
        public string Phone { get; set; }

        [JsonProperty("IdentityCard")]
        public string IdentityCard { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("PostalCode")]
        public int PostalCode { get; set; }

        [Required]
        [JsonProperty("Username")]
        public string Username { get; set; }

        [Required]
        [JsonProperty("Password")]
        public string Password { get; set; }

        //[JsonProperty("Events")]
        //public IEnumerable<Event> Events { get; set; }
    }
}