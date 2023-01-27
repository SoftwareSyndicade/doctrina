using System;
using doctrine_api.Services.SQLServer;
using doctrine_api.RequestModels;
using doctrine_api.Utilities;

namespace doctrine_api.Auth
{
    public class AuthManager : IAuthManager
    {
        private readonly DoctrinaStore _store;

        public AuthManager(DoctrinaStore store)
        {
            _store = store;
        }

        public SignInResult ValidateUser(SignInRequest signInRequest)
        {
            SignInResult signInResult = new SignInResult();

            var userAccount = (from account in _store.ACCOUNT
                               where account.USERNAME.Equals(signInRequest.USERNAME.Trim())
                               select account).FirstOrDefault();

            if (userAccount == null)
            {
                signInResult.IS_VALIDATED = false;
                signInResult.ERRORS.Add("User not found");
                return signInResult;
            }


            // validate password
            UserSecret userSecret = Utility.GetUserSecret(userAccount.SALT, signInRequest.PASSWORD.Trim());

            if (userSecret.SECRET_HASH.Equals(userAccount.PASSWORD_HASH))
            {
                signInResult.IS_VALIDATED = true;
            }

            return signInResult;
        }
    }
}

