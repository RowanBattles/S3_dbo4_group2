using System;
namespace Bussines_MenuAPI
{
    using System.Collections.Generic;
    using MenuAPI_Models.models;

    namespace YourNamespace.Services
    {
        // AccessCodeService.cs
        public class AccessCodeService
        {
            private LoginRequest _currentAccessCode;

            public LoginRequest GenerateAccessCode()
            {
                // Generate a new access code and set its expiry date (e.g., valid for a day)
                var newAccessCode = new LoginRequest
                {
                    AccessCode = GenerateRandomCode(),
                    ExpiryDate = DateTime.UtcNow.AddDays(1)
                };

                _currentAccessCode = newAccessCode;
                return newAccessCode;
            }

            public bool ValidateAccessCode(string enteredCode)
            {
                DateTime Localtime = DateTime.UtcNow;
                // Check if the entered code matches the current access code and it's not expired
                return _currentAccessCode != null &&
                       _currentAccessCode.AccessCode == enteredCode &&
                       _currentAccessCode.ExpiryDate > Localtime.AddHours(6);
            }

            private string GenerateRandomCode()
            {
                // Implement your logic to generate a random code
                // This is a placeholder; replace it with your actual code generation logic
                return "ABC123";
            }
        }
    }
}

