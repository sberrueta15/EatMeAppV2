using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatMeApp.Models
{
    public abstract class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

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

        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }
    }
}