using System;
using doctrine_api.Management.Account.Models;

namespace doctrine_api.Management.Account
{
    public interface IAccountManager
    {
        public AccountSaveStatus RegisterAccount(DataModels.Account account);
        public DataModels.Account GetAccount(String accountID);
    }
}

