using kp.Business.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.DataServies.Entities;
using kp.Business.DataServices;
using kp.Business.Entities;
using kp.Business.Data;

namespace kp.Business.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        public AuthorizationService(ITokenService tokenService)
        {
            this.TokenService = tokenService;
        }

        public User CurrentUser
            => this.Token.User;

        public ITokenService TokenService
        {
            get;
        }

        public Token Token
        {
            get;
            private set;
        }

        public string UserToken
        {
            get;
            set;
        }

        public async Task SignInAsync(string login, string password)
        {
            this.Token = await this.TokenService.GetToken(new TokenRequest
            {
                Login = login,
                Password = password
            });
            this.UserToken = this.Token.Id.ToString();
        }
    }
}
