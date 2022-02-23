using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using VegFoods.Core.Models;
using VegFoods.Core.Services;
using VegFoods.Core.StringInfos;

namespace VegFoods.Services.Services
{
    public class JwtService : IJwtService
    {
        public string GenerateJwt(User user, List<Role> roles)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.SecurityKey));

            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer: JwtInfo.Issuer, audience: JwtInfo.Audience, notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(JwtInfo.TokenExpiration), signingCredentials: signingCredentials, claims: GetClaims(user, roles));

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(jwtSecurityToken);
        }

        private List<Claim> GetClaims(User user, List<Role> roles)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));


            if (roles?.Count > 0)
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Name));
                }
            }

            return claims;
        }
    }
}
