using System.Threading.Tasks;
using kp.Domain.Data;

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