using System;
using doctrine_api.Constants;

namespace doctrine_api.ResponseModels
{
    public class SignInResponse
    {
        public bool IS_VALIDATED { get; set; }
        public List<string> ERRORS { get; set; } = new List<string>();
        public string ACCOUNT_ID { get; set; }
        public string NAME { get; set; }
        public AccountTypes ACCOUNT_TYPE { get; set; }
        public string ACCESS_TOKEN { get; set; }
    }
}

