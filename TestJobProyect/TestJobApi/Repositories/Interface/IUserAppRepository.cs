using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestJobApi.DataModels;

namespace TestJobApi.Repositories.Interface
{
    public interface IUserAppRepository
    {
       public UserApp GetUser(string username, string password);
    }
}
