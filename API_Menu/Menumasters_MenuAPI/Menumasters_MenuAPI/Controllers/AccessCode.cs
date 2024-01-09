using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using MenuAPI_Models;// Assuming your LoginRequest model is in the Models namespace
using MenuAPI_Models.models;
using Microsoft.Extensions.Options;
using Bussines_MenuAPI.YourNamespace.Services;

namespace Menumasters_MenuAPI.Controllers
{
    [Route("api")]
    public class AccessCodeController : ControllerBase
    {
        private readonly AccessCodeService _accessCodeService;

        public AccessCodeController(AccessCodeService accessCodeService)
        {
            _accessCodeService = accessCodeService;
        }

        [HttpPost("generate")]
        public IActionResult GenerateAccessCode()
        {
            var newAccessCode = _accessCodeService.GenerateAccessCode();
            return Ok(new { Code = newAccessCode.AccessCode, ExpiryDate = newAccessCode.ExpiryDate });
        }

        [HttpPost("validate")]
        public IActionResult ValidateAccessCode([FromBody] ValidateAccessCodeRequest request)
        {
            if (_accessCodeService.ValidateAccessCode(request.AccessCode))
            {
                return Ok(new { Message = "Valid access code" });
            }

            return BadRequest(new { Message = "Invalid access code" });
        }
    }

    // ValidateAccessCodeRequest.cs
    public class ValidateAccessCodeRequest
    {
        public string AccessCode { get; set; }
    }
}
