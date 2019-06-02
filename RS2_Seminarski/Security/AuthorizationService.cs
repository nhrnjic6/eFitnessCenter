using Microsoft.AspNetCore.Http;
using RS2_Seminarski.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RS2_Seminarski.Security
{
    public class AuthenticationService
    {
        public UserInfo IsAuthorized(HttpRequest request, string role)
        {
            var token = request.Headers["Authorization"];
            var claims = JWTUtil.VerifyToken(token).Claims;

            UserInfo userInfo = new UserInfo
            {
                Id = int.Parse(claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault().Value),
                Role = claims.Where(x => x.Type == ClaimTypes.Role).FirstOrDefault().Value
            };

            if (userInfo.Role != role)
            {
                throw new InvalidTokenException("Invalid role");
            }

            return userInfo;
        }
    }
}
