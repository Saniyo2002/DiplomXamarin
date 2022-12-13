namespace diplomApiV4.Security
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, Client user);
        bool ValidateToken(string key, string issuer, string audience, string token);
    }
}
