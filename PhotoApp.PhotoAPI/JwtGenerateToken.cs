using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PhotoApp.PhotoAPI
{
    public class JwtGenerateToken
    {
        public string GenerateToken()
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("PhotoJwtxTokens."));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));

            JwtSecurityToken token = new JwtSecurityToken(issuer:"http://localhost",claims: claims, audience: "http://localhost",notBefore:DateTime.Now, expires:DateTime.Now.AddMinutes(1),signingCredentials:credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            
          return  handler.WriteToken(token);
        }
    }
}
