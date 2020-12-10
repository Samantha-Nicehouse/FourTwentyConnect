using dk.via.ftc.businesslayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.via.ftc.web.Data
{
    public interface IUserManager
    {
        public Task<User> ValidateUser(string userName, string passWord);
        public Task userNameInUseAsync(string username);
    }
}
