using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using kp.Business.Abstraction;
using kp.ViewModels.Core;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using WpfToolkit.Routing.Abstractions;

namespace kp.ViewModels
{

    public class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel(IAuthorizationService authorizationService, INavigator navigator)
        {
            this.Logout = ReactiveCommand.Create(() => authorizationService.Logout());
            this.Languages = new[] {
                new KeyValuePair<string, string>("English", "en-en"),
                new KeyValuePair<string, string>("Руский", "ru-ru")
            };

            this.SelectedLanguage = this.Languages[1];

            this.WhenAnyValue(o => o.SelectedLanguage).
                Subscribe(o => 
                {
                    CultureInfo.CurrentUICulture = new CultureInfo(o.Value);
                });

            TrySingInAsync(authorizationService, navigator);
        }

        private static async void TrySingInAsync(IAuthorizationService authorizationService, INavigator navigator)
        {
            await authorizationService.SignInFromStorageAsync();
            if (authorizationService.CurrentUser is null)
            {
                navigator.Navigate(Resources.Routes.Login);
            }
            else
            {
                navigator.Navigate(Resources.Routes.Main);
            }
        }

        public ReactiveCommand<Unit, Unit> Logout
        {
            get;
        }

        public KeyValuePair<string, string>[] Languages
        {
            get;
        }

        [Reactive]
        public KeyValuePair<string, string> SelectedLanguage
        {
            get;
            set;
        }
    }
}
