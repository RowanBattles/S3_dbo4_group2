﻿using System;
namespace MenuAPI_Models.models
{
    public class LoginRequest
    {
        public string AccessCode { get; set; }
        public DateTime ExpiryDate { get; set; }

    }
}

