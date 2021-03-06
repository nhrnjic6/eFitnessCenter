﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models.Token;
using RS2_Seminarski.Database;
using RS2_Seminarski.Exceptions;
using RS2_Seminarski.Services;
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
        private readonly UserStatusService _userStatusService;

        public AuthenticationService(FitnessCenterDbContext context)
        {
            _context = context;
            _userStatusService = new UserStatusService(_context);
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

        public UserInfo IsAuthorized(HttpRequest request, string[] roles)
        {
            var token = request.Headers["Authorization"];
            var claims = JWTUtil.VerifyToken(token).Claims;

            UserInfo userInfo = new UserInfo
            {
                Id = int.Parse(claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault().Value),
                Role = claims.Where(x => x.Type == ClaimTypes.Role).FirstOrDefault().Value
            };

            if (!roles.Contains(userInfo.Role))
            {
                throw new InvalidTokenException("Invalid role");
            }

            return userInfo;
        }

        public TokenInformation AuthenticateUser(string email, string password)
        {
            string hashedPassword = HashUtil.ComputeSha256Hash(password);
            AppUser appUser = _context.AppUsers
                .Include(user => user.Employee)
                .Include(user => user.Client)
                .ThenInclude(x => x.MembershipPayments)
                .Include(user => user.Trainer)
                .Where(x => x.Email == email)
                .Where(x => x.HashedPassword == hashedPassword)
                .FirstOrDefault();

            if(appUser == null)
            {
                throw new InvalidCredentialsException("Invalid username or password");
            }

            return GetToken(appUser);
        }

        private TokenInformation GetToken(AppUser appUser)
        {
            string role;

            if(appUser.Client != null)
            {
                UserStatus userStatus = _userStatusService.CalculateUserStatus(appUser);
                if (userStatus != UserStatus.ACTIVE)
                {
                    throw new InvalidCredentialsException("Invalid username or password");
                }

                role = "CLIENT";
            }else if(appUser.Employee != null)
            {
                role = "EMPLOYEE";
            }
            else if(appUser.Trainer != null)
            {
                role = "TRAINER";
            }
            else
            {
                throw new Exception("Invalid user without assigned role");
            }

            return new TokenInformation
            {
                AccessToken = JWTUtil.CreateToken(appUser.Id, role),
                Role = role
            };
        }
    }
}
