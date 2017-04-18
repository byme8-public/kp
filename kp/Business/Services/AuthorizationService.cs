using System;
using System.IO;
using System.Threading.Tasks;
using kp.Business.Abstraction;
using kp.Business.Data;
using kp.Business.DataServices;
using kp.Business.Settings;
using kp.Domain.Data;
using kp.Resources;
using Storage;
using WpfToolkit.Routing.Abstractions;

namespace kp.Business.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        public ITokenService TokenService
        {
            get;
        }

        public INavigator Navigator
        {
            get;
        }

        public SettingManager SettingManager
        {
            get;
        }

        public AuthorizationService(ITokenService tokenService, INavigator navigator, SettingManager settingManager)
        {
            this.TokenService = tokenService;
            this.Navigator = navigator;
            this.SettingManager = settingManager;
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
            this.SettingManager.Settings.UserToken = null;
            this.Navigator.Navigate(Routes.Login);
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
            try
            { 
                if (this.SettingManager.Settings.UserToken.HasValue)
                    this.SetToken(await this.TokenService.GetTokenById(this.SettingManager.Settings.UserToken.Value));
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
            this.SettingManager.Settings.UserToken = this.Token.Id;
        }
    }
}