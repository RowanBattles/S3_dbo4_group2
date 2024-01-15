using System;
namespace Bussines_MenuAPI
{
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;
    using MenuAPI_Models.models;

    namespace YourNamespace.Services
    {
        // AccessCodeService.cs
        public class AccessCodeService
        {
            private LoginRequest _currentAccessCode;

            public string GetAccessCode()
            {
                return _currentAccessCode.AccessCode;
            }

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
                return GenerateRandomString(6); // You can adjust the length as needed
            }

            private string GenerateRandomString(int length)
            {
                const string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                StringBuilder stringBuilder = new StringBuilder(length);

                using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
                {
                    byte[] randomBytes = new byte[length];
                    rng.GetBytes(randomBytes);

                    foreach (byte b in randomBytes)
                    {
                        stringBuilder.Append(characters[b % (characters.Length)]);
                    }
                }

                return stringBuilder.ToString();
            }
        }
    }
}

