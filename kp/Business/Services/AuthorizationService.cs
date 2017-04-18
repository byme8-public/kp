using System;
using System.IO;
using System.Threading.Tasks;
using kp.Business.Abstraction;
using kp.Business.Data;
using kp.Business.DataServices;
using kp.Domain.Data;

namespace kp.Business.Services
{
    public class AuthorizationService : IAuthorizationService, IDisposable
    {
        public AuthorizationService(ITokenService tokenService)
        {
            this.TokenService = tokenService;
        }

        public User CurrentUser
            => this.Token?.User;

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

        public void Dispose()
        {

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

        public async Task SignInFromStorageAsync()
        {
            Guid token = Guid.Empty;
            try
            {
                using (var input = new StreamReader("token"))
                {
                    if (!Guid.TryParse(input.ReadLine(), out token))
                        return;
                }

                this.Token = await this.TokenService.GetTokenById(token);
                this.UserToken = this.Token.Id.ToString();
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}