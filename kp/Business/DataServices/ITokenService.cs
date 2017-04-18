using System;
using System.Threading.Tasks;
using kp.Business.Data;
using kp.Domain.Data;
using Refit;

namespace kp.Business.DataServices
{
    public interface ITokenService
    {
        [Post("")]
        Task<Token> GetToken(TokenRequest request);

        [Get("/{token}")]
        Task<Token> GetTokenById(Guid token);
    }
}