using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static AggregationService.Abstraction.AuthenticationModels;

namespace AggregationService.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public ActionResult Login([FromBody] LoginRequest request)
        {
            var jwt = _configuration.GetSection("JWT");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Secret"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, request.Username),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(ClaimTypes.Name, request.Username),
            };

            var token = new JwtSecurityToken(
                issuer: jwt["ValidIssuer"],
                audience: jwt["ValidAudience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            Response.Cookies.Append("jwt", tokenString, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,                 
                SameSite = SameSiteMode.None,
                Expires = DateTimeOffset.UtcNow.AddHours(1)
            });

            return Ok(new { access_token = tokenString });
        }
    }
}
