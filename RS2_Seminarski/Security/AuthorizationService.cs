using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RS2_Seminarski.Database;
using RS2_Seminarski.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Seminarski.Security
{
    public class AuthenticationService
    {
        private readonly FitnessCenterDbContext _context;

        public AuthenticationService(FitnessCenterDbContext context)
        {
            _context = context;
        }

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

        public string AuthenticateUser(string email, string password)
        {
            string hashedPassword = HashUtil.ComputeSha256Hash(password);
            AppUser appUser = _context.AppUsers
                .Include(user => user.Employee)
                .Include(user => user.Client)
                .Where(x => x.Email == email)
                .Where(x => x.HashedPassword == hashedPassword)
                .FirstOrDefault();

            if(appUser == null)
            {
                throw new InvalidCredentialsException("Invalid username or password");
            }

            return GetToken(appUser);
        }

        private string GetToken(AppUser appUser)
        {
            string role;

            if(appUser.Client != null)
            {
                role = "CLIENT";
            }else if(appUser.Employee != null)
            {
                role = "EMPLOYEE";
            }
            else
            {
                throw new Exception("Invalid user without assigned role");
            }

            return JWTUtil.CreateToken(appUser.Id, role);
        }
    }
}
