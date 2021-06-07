using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestJobApi.DataModels;
using TestJobApi.Repositories.Interface;

namespace TestJobApi.Repositories
{
    public class UserAppRepository :IUserAppRepository
    {
        private readonly MyAplicationContext db;
        public UserAppRepository(MyAplicationContext _db)
        {
            db = _db;
        }

        public UserApp GetUser(string username, string password)
        {
            return db.UserApp.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
        }
    }
}
