using EatMeApp.DTOs;
using EatMeApp.Models;
using EatMeApp.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Dynamic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace EatMeApp.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        public readonly AppDbContext _context;

        private readonly JsonSerializerSettings _serializerSettings;

        public LoginController(AppDbContext context)
        {
            _context = context;

            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] LoginDTO LoginDTO)
        {
            var identity = await GetClaimsIdentity(LoginDTO);
            if (identity == null)
            {
                return BadRequest("Invalid credentials");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, LoginDTO.UserName),
                new Claim(JwtRegisteredClaimNames.Iat,
                          ClaimValueTypes.Integer64),
                identity.FindFirst("DisneyCharacter")
              };

            // Create the JWT security token and encode it.
            var jwt = new JwtSecurityToken(
                issuer: identity.Name,
                claims: claims,
                expires: DateTime.Now.AddHours(6));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            

            User dbUser;
            if (LoginDTO.app.Equals("cooker"))
            {
                dbUser = _context.Cookers.SingleOrDefault(u => u.Username == LoginDTO.UserName && u.Password == LoginDTO.Password);
            }
            else
            {
                dbUser = _context.Commnesals.SingleOrDefault(u => u.Username == LoginDTO.UserName && u.Password == LoginDTO.Password);
            }
            

            //var json = JsonConvert.SerializeObject(response, _serializerSettings);
            // Serialize and return the response
            var response = new
            {
                access_token = encodedJwt,
                user = dbUser
            };
            //dynamic x = new { access_token = encodedJwt, user = dbUser };

            return new OkObjectResult(response);
        }

        

        /// <returns>Date converted to seconds since Unix epoch (Jan 1, 1970, midnight UTC).</returns>
        private static long ToUnixEpochDate(DateTime date)
          => (long)Math.Round((date.ToUniversalTime() -
                               new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
                              .TotalSeconds);

        /// <summary>
        /// You'd want to retrieve claims through your claims provider
        /// in whatever way suits you, the below is purely for demo purposes!
        /// </summary>
        private Task<ClaimsIdentity> GetClaimsIdentity(LoginDTO user)
        {
            if (user.app.Equals("cooker"))
            {
                var cooker = _context.Cookers.SingleOrDefault(u => u.Username == user.UserName && u.Password == user.Password);
                if (cooker != null)
                {
                    return Task.FromResult(new ClaimsIdentity(
                      new GenericIdentity(cooker.Id.ToString(), "Token"),
                      new[]
                      {
            new Claim("User", user.UserName)
                      }));
                }

                // Credentials are invalid, or account doesn't exist
                return Task.FromResult<ClaimsIdentity>(null);
            }
            else
            {
                var commensal = _context.Commnesals.SingleOrDefault(u => u.Username == user.UserName && u.Password == user.Password);
                if (commensal != null)
                {
                    return Task.FromResult(new ClaimsIdentity(
                      new GenericIdentity(commensal.Id.ToString(), "Token"),
                      new[]
                      {
            new Claim("User", user.UserName)
                      }));
                }

                // Credentials are invalid, or account doesn't exist
                return Task.FromResult<ClaimsIdentity>(null);
            }

            
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(new LoginDTO());
        }
    }
}