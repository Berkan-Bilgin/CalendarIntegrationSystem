using Core.Entities;
using Core.Utilities.Encryption;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.JWT
{
    public class JwtHelper : ITokenHelper
    {
        private readonly TokenOptions tokenOptions;

        public JwtHelper(TokenOptions tokenOptions)
        {
            this.tokenOptions = tokenOptions;
        }

        public AccessToken CreateToken(BaseUser user, List<OperationClaim> operationClaims)
        {
            DateTime expirationTime = DateTime.Now.AddMinutes(tokenOptions.ExpirationTime);
            SecurityKey key = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey);

            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                claims: SetAllClaims(user, operationClaims.Select(i => i.Name).ToList()),
                notBefore: DateTime.Now,
                expires: expirationTime,
                signingCredentials: signingCredentials
                );

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            string jwtToken = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken() { Token = jwtToken, ExpirationTime = expirationTime };
        }

        protected IEnumerable<Claim> SetAllClaims(BaseUser user, List<string> operationClaims)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            //TODO: Email bugu var buna bak bir ara.

            claims.Add(new Claim(ClaimTypes.Name, user.FirstName ?? "undefined"));
            /*if (!string.IsNullOrEmpty(user.Email))
            {
                claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            }*/

            foreach (var operationClaim in operationClaims)
            {
                claims.Add(new Claim(ClaimTypes.Role, operationClaim));
            }
            return claims;
        }
    }
}
