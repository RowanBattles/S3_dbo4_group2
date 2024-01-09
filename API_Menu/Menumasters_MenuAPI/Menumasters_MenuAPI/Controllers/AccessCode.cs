using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using MenuAPI_Models;// Assuming your LoginRequest model is in the Models namespace
using MenuAPI_Models.models;

namespace Menumasters_MenuAPI.Controllers
{
    [Route("api")]
    public class AccessCodeController : ControllerBase
    {
        private readonly TokenConfiguration _tokenConfig;

        public AccessCodeController(TokenConfiguration tokenConfig)
        {
            _tokenConfig = tokenConfig;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest model)
        {
            // Validate the access code (implement your own logic)
            if (IsValidAccessCode(model.AccessCode))
            {
                // Generate a JWT token and return it
                var token = GenerateJwtToken();
                return Ok(new { Token = token });
            }

            return BadRequest(new { Message = "Invalid access code" });
        }

        private bool IsValidAccessCode(string accessCode)
        {
            // Implement your logic to validate the access code (e.g., check against a database)
            // This is a placeholder, replace it with your actual validation logic
            return accessCode == "your-secret-access-code";
        }

        private string GenerateJwtToken()
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, "guest"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_tokenConfig.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _tokenConfig.Issuer,
                audience: _tokenConfig.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_tokenConfig.ExpirationInMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
