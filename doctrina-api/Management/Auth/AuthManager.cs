using System;
using doctrine_api.Services.SQLServer;
using doctrine_api.RequestModels;
using doctrine_api.Utilities;
using doctrine_api.Management.Auth.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.Extensions.Options;

namespace doctrine_api.Management.Auth;

public class AuthManager : IAuthManager
{
    private readonly DoctrinaStore _store;
    private readonly JWTSecret _jWTSecret;

    public AuthManager(DoctrinaStore store, IOptions<JWTSecret> jWTSecret)
    {
        _store = store;
        _jWTSecret = jWTSecret.Value;
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
        UserSecret userSecret = Utilities.Utility.GetUserSecret(userAccount.SALT, signInRequest.PASSWORD.Trim());

        if (userSecret.SECRET_HASH.Equals(userAccount.PASSWORD_HASH))
        {
            signInResult.IS_VALIDATED = true;
            signInResult.ACCOUNT_ID = userAccount.ID;
            signInResult.ACCOUNT_TYPE = userAccount.ACCOUNT_TYPE;
            signInResult.NAME = userAccount.FIRST_NAME + " " + userAccount.LAST_NAME;
            signInResult.ACCESS_TOKEN = GenerateJwtToken(signInResult);
        }

        return signInResult;
    }

    private string GenerateJwtToken(SignInResult signInResult)
    {

        List<Claim> claims = new();

        claims.Add(new Claim(ClaimTypes.NameIdentifier, signInResult.ACCOUNT_ID));
        claims.Add(new Claim(ClaimTypes.Name, signInResult.NAME));
        claims.Add(new Claim("ACCOUNT_TYPE", signInResult.ACCOUNT_TYPE.ToString()));

        ClaimsIdentity claimsIdentity = new(claims);

        using RSA rsa = RSA.Create();

        rsa.ImportFromPem(_jWTSecret.PRIVATE_KEY.ToCharArray());

        SigningCredentials credentials = new(
            key: new RsaSecurityKey(rsa),
            algorithm: SecurityAlgorithms.RsaSha256
        )
        {
            CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
        };

        DateTime jwtDate = DateTime.UtcNow;

        SecurityTokenDescriptor securityToken = new()
        {
            Subject = claimsIdentity,
            Issuer = _jWTSecret.ISSUER,
            Audience = _jWTSecret.AUDIENCE,
            NotBefore = jwtDate,
            Expires = jwtDate.AddMinutes(_jWTSecret.TTL),
            SigningCredentials = credentials
        };

        var token = new JwtSecurityTokenHandler().CreateToken(securityToken);

        return new JwtSecurityTokenHandler().WriteToken(token);

    }
}

