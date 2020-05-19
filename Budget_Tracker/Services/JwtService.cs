using Budget_Tracker.Database;
using Budget_Tracker.Helpers;
using Budget_Tracker.Models;
using Budget_Tracker.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Budget_Tracker.Services
{
    public class JwtService : IJwtService
    {
        private readonly BudgetTrackerContext _context;
        private readonly AppSettings _appSettings;
        private string _token;

        public JwtService(IOptions<AppSettings> appSettings,IHttpContextAccessor httpContextAccessor, BudgetTrackerContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
            _token = httpContextAccessor.HttpContext.Request.Headers["Authorization"];
        }

        public JwtToken GenerateJwtToken(string username)
        {
            User user = _context.Users.SingleOrDefault(i => i.UserName == username);

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = new JwtToken()
            {
                AccessToken = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor)),
            };
            return token;
        }

        public int GetUserId()
        {
            try
            {
                if (_token.StartsWith("Bearer "))
                {
                    _token = _token.Substring("Bearer ".Length);
                }
                var handler = new JwtSecurityTokenHandler() { SetDefaultTimesOnTokenCreation = false };
                var payload = handler.ReadJwtToken(_token.Trim());
                var userId = Convert.ToInt32(payload.Payload.Values.First());
                if (userId != 0)
                    return userId;

                return -1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
