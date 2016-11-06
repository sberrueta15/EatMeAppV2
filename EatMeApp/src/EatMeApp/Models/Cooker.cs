using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EatMeApp.Models
{
    public class Cooker : User
    {
        [JsonProperty("descripcion")]
        public string Bio { get; set; }
    }
}
