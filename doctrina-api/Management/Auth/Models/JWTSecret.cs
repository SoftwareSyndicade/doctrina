namespace doctrine_api.Management.Auth.Models;

public class JWTSecret
{
    public string PRIVATE_KEY { get; set; }
    public string PUBLIC_KEY { get; set; }
    public string ISSUER { get; set; }
    public string AUDIENCE { get; set; }
    public int TTL { get; set; }
}

