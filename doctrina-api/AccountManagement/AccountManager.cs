using System;
using doctrine_api.DataModels;
using doctrine_api.Services.SQLServer;
using doctrine_api.Utilities;

namespace doctrine_api.AccountManagement
{
    public class AccountManager : IAccountManager
    {
        private readonly DoctrinaStore _store;

        public AccountManager(DoctrinaStore store)
        {
            _store = store;
        }

        public AccountSaveStatus RegisterAccount(Account account)
        {
            AccountSaveStatus saveStatus = new AccountSaveStatus();

            // check for account in store if it exist.
            var existingAccount = (from acc in _store.ACCOUNT where acc.USERNAME == account.USERNAME select acc).FirstOrDefault();

            if (existingAccount != null)
            {
                saveStatus.STATUS = false;
                saveStatus.ERRORS.Add("Account for this username already exist.");
            }

            // create ID for account
            account.ID = Guid.NewGuid().ToString();
            // hash password.

            UserSecret userSecret = Utilities.Utility.GetUserSecret(null, account.PASSWORD);

            account.PASSWORD_HASH = userSecret.SECRET_HASH;
            account.SALT = userSecret.SALT;

            _store.ACCOUNT.Add(account);
            int entryCount = _store.SaveChanges();

            if (entryCount == 1)
            {
                saveStatus.STATUS = true;
                return saveStatus;
            }
            else
            {
                saveStatus.STATUS = false;
                return saveStatus;
            }

        }
    }
}

