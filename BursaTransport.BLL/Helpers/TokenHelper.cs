using BursaTransport.BLL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BursaTransport.DAL.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace BursaTransport.BLL.Helper
    {
        public class TokenHelper : ITokenHelper
        {
            private readonly UserManager<User> _userManager;

            public TokenHelper(UserManager<User> userManager)
            {
                _userManager = userManager;
            }

            public async Task<string> CreateAccessToken(User _User)
            {
                var userId = _User.Id.ToString();
                var userName = _User.UserName;

                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, userName)
            };

                var roles = await _userManager.GetRolesAsync(_User);

                foreach (var role in roles) claims.Add(new Claim(ClaimTypes.Role, role));

                var secret = "200519481478134923659431346289";

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddMinutes(10),
                    SigningCredentials = creds
                };

                var tokenHandler = new JwtSecurityTokenHandler();

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }

            public string CreateRefreshToken()
            {
                var randomNumber = new byte[32];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(randomNumber);
                    return Convert.ToBase64String(randomNumber);
                }
            }

            public ClaimsPrincipal GetPrincipalFromExpiredToken(string _Token)
            {
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("200519481478134923659431346289")),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                IdentityModelEventSource.ShowPII = true;
                var tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken securityToken;

                var principal = tokenHandler.ValidateToken(_Token, tokenValidationParameters, out securityToken);
                var jwtSecurityToken = securityToken as JwtSecurityToken;
                if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals("hs512", StringComparison.InvariantCultureIgnoreCase))
                    throw new SecurityTokenException("Invalid token");

                return principal;
            }
        }
    }
