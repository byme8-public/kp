using kp.Business.Data;
using kp.Business.Entities;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kp.Business.DataServices
{
    public interface ITokenService
    {
        [Post("")]
        Task<Token> GetToken(TokenRequest request);
    }
}
