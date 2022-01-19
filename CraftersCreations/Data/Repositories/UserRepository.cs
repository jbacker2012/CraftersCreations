using System.Collections.Generic;
using System.Linq;
using CraftersCreations.Models;

namespace CraftersCreations.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
       
        private readonly CraftDbContext dbContext;

        public UserRepository(CraftDbContext dbContext)
        {
            this.dbContext = dbContext;

        }

        //public User GetByUsernameAndPassword(string username, string password)
        //{
        //    var user = dbContext.User.SingleOrDefault(u => u.Name == username &&
        //        u.Password == password.Sha256());
        //    return user;
        //}

        public User GetByGoogleId(string googleId)
        {
            var user = dbContext.User.SingleOrDefault(u => u.Email == googleId);
            //var user = users.SingleOrDefault(u => u.GoogleId == googleId);
            return user;
        }
    }
}
