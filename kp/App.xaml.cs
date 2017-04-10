using System.Windows;
using kp.Business;
using kp.Business.Exceptions;
using kp.ViewModels;
using kp.ViewModels.Login;
using kp.ViewModels.UserRoles;
using kp.ViewModels.Users;
using kp.Views;
using kp.Views.Login;
using kp.Views.UserRoles;
using kp.Views.Users;
using WpfToolkit.Routing;
using WpfToolkit.Services;

namespace kp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Routes.Configure(routes =>
            {
                routes.Add<Login, LoginViewModel>("login");
                routes.Add<MainView, MainViewModel>("main");
                routes.Add<UsersView, UsersListViewModel>(kp.Resources.Routes.Users);
                routes.Add<NewUserView, NewUserViewModel>(kp.Resources.Routes.NewUser);
                routes.Add<EditUserView, EditUserViewModel>(kp.Resources.Routes.EditUser);
                routes.Add<UserRolesView, UserRolesViewModel>(kp.Resources.Routes.UserRoles);
                routes.Add<NewUserRole, NewUserRoleViewModel>(kp.Resources.Routes.NewUserRole);
            });

            Services.Configure(services =>
            {
                services.AddRouting();
                services.AddDataServices();
                services.AddViewModels();
                services.AddViews();
            });

            this.DispatcherUnhandledException += ExceptionHander.App_DispatcherUnhandledException;
        }
    }
}