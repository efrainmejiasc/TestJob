using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestJobApi.DataModels;
using TestJobApi.Repositories.Interface;

namespace TestJobApi.Repositories
{
    public class UserRepository :IUserRepository
    {
        private readonly MyAplicationContext db;
        public UserRepository(MyAplicationContext _db)
        {
            db = _db;
        }

        public UserApp GetUser(string username, string password)
        {
            return db.User.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
        }
    }
}
