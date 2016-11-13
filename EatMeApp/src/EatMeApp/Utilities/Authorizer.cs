using EatMeApp.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace EatMeApp.Utilities
{
    public class Authorizer
    {
        public static bool HasAccess(string token, AppDbContext _context)
        {
            var JwtHandler = new JwtSecurityTokenHandler();
            var decodedToken = JwtHandler.ReadJwtToken(token);
            var userId = int.Parse(decodedToken.Issuer);
            var cooker = _context.Cookers.SingleOrDefault(x => x.Id == userId);
            var commensal = _context.Commnesals.SingleOrDefault(x => x.Id == userId);
            if (cooker.Username == decodedToken.Subject || commensal.Username == decodedToken.Subject)
            {
                return true;
            }
            return false;
        }
    }
}
