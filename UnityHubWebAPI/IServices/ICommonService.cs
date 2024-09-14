namespace UnityHubWebAPI.IServices
{
    public interface ICommonService
    {
        (string hashedPassword, string salt) HashPassword(string password);
        bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt);
    }
}
