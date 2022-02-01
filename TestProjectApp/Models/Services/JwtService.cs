using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace TestProjectApp.Models.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateJwtToken(ApplicationUser user, IList<string> userRoles, IEnumerable<Claim> claims)
        {
            List<Claim> claimList = new List<Claim>();
            claimList.Add(new Claim(JwtRegisteredClaimNames.Sub, user.UserName));
            claimList.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claimList.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claimList.Add(new Claim(ClaimTypes.Name, user.UserName));
            if (user.ComputerId != null)
            {
                claimList.Add(new Claim("Computer:", user.ComputerId.ToString()));
            }


            foreach (var role in userRoles)
            {
                claimList.Add(new Claim(ClaimTypes.Role, role));
            }

            claimList.AddRange(claims);

            int expiraionDays = _configuration.GetValue<int>("JWTConfiguration:TokenExpirationDays");
            byte[] signingKey = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWTConfiguration:SigningKey"));
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("JWTConfiguration:Issuer"),
                audience: _configuration.GetValue<string>("JWTConfiguration:Audience"),
                claims: claimList,
                expires: DateTime.UtcNow.AddDays(expiraionDays),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
