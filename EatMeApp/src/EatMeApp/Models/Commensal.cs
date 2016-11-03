using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EatMeApp.Models
{
    public class Commensal : User
    {
        [JsonProperty("Preferences")]
        public string Preferences { get; set; }
    }
}
