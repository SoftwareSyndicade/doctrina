using System;
using doctrine_api.DataModels;

namespace doctrine_api.AccountManagement
{
    public interface IAccountManager
    {
        public AccountSaveStatus RegisterAccount(Account account);
    }
}

