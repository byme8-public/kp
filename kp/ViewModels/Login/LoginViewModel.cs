using System;
using System.Reactive;
using kp.Business.Abstraction;
using kp.ViewModels.Core;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using WpfToolkit.Routing.Abstractions;

namespace kp.ViewModels.Login
{
    public class LoginViewModel : ViewModel
    {
        public LoginViewModel(IAuthorizationService authorizationService, INavigator navigator)
        {
            this.SignIn = ReactiveCommand.CreateFromTask(() => authorizationService.SignInAsync(this.Login, this.Password));
            this.SignIn.Subscribe(o => navigator.Navigate("main"));
            //this.SignIn.ThrownExceptions
        }

        [Reactive]
        public string Login
        {
            get;
            set;
        }

        [Reactive]
        public string Password
        {
            get;
            set;
        }

        public IAuthorizationService AuthorizationService
        {
            get;
        }

        public ReactiveCommand<Unit, Unit> SignIn { get; private set; }
    }
}