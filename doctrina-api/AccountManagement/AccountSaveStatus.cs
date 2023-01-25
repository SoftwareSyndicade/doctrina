using System;
using System.Collections.Generic;

namespace doctrine_api.AccountManagement
{
    public class AccountSaveStatus
    {
        public bool STATUS { get; set; }
        public List<string> ERRORS { get; set; } = new List<string>();
    }
}

