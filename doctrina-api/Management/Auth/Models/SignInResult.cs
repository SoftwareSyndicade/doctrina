using System;
namespace doctrine_api.Management.Auth.Models
{
    public class SignInResult
    {
        public bool IS_VALIDATED { get; set; }
        public List<string> ERRORS { get; set; } = new List<string>();
    }
}

