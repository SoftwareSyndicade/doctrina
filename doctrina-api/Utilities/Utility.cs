﻿using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace doctrine_api.Utilities
{
    public class Utility
    {
        public static UserSecret GetUserSecret(byte[]? salt, string password)
        {
            if (salt == null) // create new salt
            {
                // generate a 128-bit salt using a secure PRNG
                salt = new byte[128 / 8];
                using var rng = RandomNumberGenerator.Create();
                rng.GetBytes(salt);
            }

            // derive a 256-bit subkey (use HMACSHA256 with 10,000 iterations)
            var secretHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password,
                salt,
                KeyDerivationPrf.HMACSHA256,
                10000,
                256 / 8));

            UserSecret userSecret = new() { SALT = salt, SECRET_HASH = secretHash };

            return userSecret;
        }
    }
}

