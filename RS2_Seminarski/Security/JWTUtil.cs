using Microsoft.IdentityModel.Tokens;
using RS2_Seminarski.Exceptions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Seminarski.Security
{
    public static class JWTUtil
    {
        public static string CreateToken(int userId, string role)
        {
            var handler = new JwtSecurityTokenHandler();
            var secretString = "THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING";
            byte[] buffer = Encoding.ASCII.GetBytes(secretString);

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor();
            securityTokenDescriptor.Expires = DateTime.UtcNow.AddDays(1);
            securityTokenDescriptor.SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(buffer), SecurityAlgorithms.HmacSha256Signature);
            securityTokenDescriptor.Subject = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, userId.ToString()),
                new Claim(ClaimTypes.Role, role)
            });

            SecurityToken securityToken = handler.CreateToken(securityTokenDescriptor);
            return handler.WriteToken(securityToken);
        }

        public static ClaimsPrincipal VerifyToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var secretString = "THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING";
            byte[] buffer = Encoding.ASCII.GetBytes(secretString);

            SecurityToken validatedToken;
            var param = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(buffer),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true
            };

            try
            {
                return handler.ValidateToken(token, param, out validatedToken);
            }
            catch(Exception e)
            {
                throw new InvalidTokenException("Invalid token provided");
            }
        }
    }
}
