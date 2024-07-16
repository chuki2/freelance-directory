using System;
using System.Security.Cryptography;
using System.Text;

namespace FreelancerDirectoryAPI.Application
{
    public static class CacheKeyHelper
    {
        public static string GenerateCacheKeyFromParams(object parameters)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(parameters);
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(json));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
