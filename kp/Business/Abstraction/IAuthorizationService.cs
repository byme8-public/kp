using System.Threading.Tasks;
using kp.DataServies.Entities;

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