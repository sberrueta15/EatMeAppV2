using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatMeApp.Models
{
    public abstract class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("id")]
        public int Id { get; set; }

        [Required]
        [JsonProperty("nombre")]
        public string FirstName { get; set; }

        [Required]
        [JsonProperty("apellido")]
        public string LastName { get; set; }

        [Required]
        [JsonProperty("email")]
        public string EmailAddress { get; set; }

        [JsonProperty("telefono")]
        public string Phone { get; set; }

        [JsonProperty("cedula")]
        public string IdentityCard { get; set; }

        [JsonProperty("direccion")]
        public string Address { get; set; }

        [JsonProperty("codigo_postal")]
        public int PostalCode { get; set; }

        [Required]
        [JsonProperty("usuario")]
        public string Username { get; set; }

        [Required]
        [JsonProperty("contraseña")]
        public string Password { get; set; }

        //[JsonProperty("Events")]
        //public IEnumerable<Event> Events { get; set; }
    }
}