using System;
using doctrine_api.RequestModels;

namespace doctrine_api.Auth
{
    public interface IAuthManager
    {
        public SignInResult ValidateUser(SignInRequest signInRequest);
    }
}

