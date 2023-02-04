using System;
using System.Collections.Generic;

namespace doctrine_api.Management.Account.Models
{
    public class AccountSaveStatus
    {
        public bool STATUS { get; set; }
        public string ACCOUNT_ID { get; set; }
        public List<string> ERRORS { get; set; } = new List<string>();
    }
}

