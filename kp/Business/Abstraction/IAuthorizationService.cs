using kp.Business.Entities;
using kp.DataServies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kp.Business.Abstraction
{
    public interface IAuthorizationService
    {
        User CurrentUser
        {
            get;
        }

        string UserToken
        {
            get;
        }

        Task SignInAsync(string login, string password);
    }
}
