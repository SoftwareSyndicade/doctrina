using System;
namespace doctrine_api.ResponseModels
{
    public class SignInResponse
    {
        public bool IS_VALIDATED { get; set; }
        public List<string> ERRORS { get; set; } = new List<string>();
    }
}

