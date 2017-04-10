using System.Threading.Tasks;
using kp.Business.Data;
using kp.Business.Entities;
using Refit;

namespace kp.Business.DataServices
{
    public interface ITokenService
    {
        [Post("")]
        Task<Token> GetToken(TokenRequest request);
    }
}