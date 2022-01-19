using CraftersCreations.Models;

namespace CraftersCreations.Data.Repositories
{
    public interface IUserRepository
    {
        //User GetByUsernameAndPassword(string username, string password);
        User GetByGoogleId(string googleId);
    }
}