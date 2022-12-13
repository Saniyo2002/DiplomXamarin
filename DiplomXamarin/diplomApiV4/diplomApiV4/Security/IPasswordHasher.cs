namespace diplomApiV4.Security
{
    public interface IPasswordHasher
    {
        string CalculateHash(string password);
        bool CheckPassword(string password, string hashFromDatabase);
    }
}
