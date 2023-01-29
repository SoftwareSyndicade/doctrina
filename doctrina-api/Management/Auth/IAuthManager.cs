using System;
using doctrine_api.Management.Auth.Models;
using doctrine_api.RequestModels;

namespace doctrine_api.Management.Auth
{
    public interface IAuthManager
    {
        public SignInResult ValidateUser(SignInRequest signInRequest);
    }
}

