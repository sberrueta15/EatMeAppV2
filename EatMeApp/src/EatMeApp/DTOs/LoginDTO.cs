using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EatMeApp.DTOs
{
    public class LoginDTO
    {
        /// <summary>
        /// User email or login name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        public string Password { get; set; }
    }
}
