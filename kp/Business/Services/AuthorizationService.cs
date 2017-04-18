using System;
using System.IO;
using System.Threading.Tasks;
using kp.Business.Abstraction;
using kp.Business.Data;
using kp.Business.DataServices;
using kp.Domain.Data;
using kp.Resources;
using WpfToolkit.Routing.Abstractions;

namespace kp.Business.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        const string TokenFile = "token";

        public ITokenService TokenService
        {
            get;
        }

        public INavigator Navigator
        {
            get;
        }

        public AuthorizationService(ITokenService tokenService, INavigator navigator)
        {
            this.TokenService = tokenService;
            this.Navigator = navigator;
        }

        public User CurrentUser
            => this.Token?.User;

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

        public void Logout()
        {
            this.Token = null;
            this.UserToken = null;
            File.Delete(TokenFile);
            this.Navigator.Navigate(Routes.Login);
        }

        public void SaveTokenToStorage()
        {
            if (string.IsNullOrWhiteSpace(this.UserToken))
                return;

            using (var output = new StreamWriter(TokenFile))
            {
                output.WriteLine(this.UserToken);
            }
        }

        public async Task SignInAsync(string login, string password)
        {
            this.SetToken(await this.TokenService.GetToken(new TokenRequest
            {
                Login = login,
                Password = password
            }));
        }

        public async Task SignInFromStorageAsync()
        {
            Guid token = Guid.Empty;
            try
            {
                using (var input = new StreamReader(TokenFile))
                {
                    if (!Guid.TryParse(input.ReadLine(), out token))
                        return;
                }

                this.SetToken(await this.TokenService.GetTokenById(token));
            }
            catch (Exception)
            {
                return;
            }
        }

        private void SetToken(Token token)
        {
            this.Token = token;
            this.UserToken = this.Token?.Id.ToString();
        }
    }
}