using System.Globalization;
using System.Windows;
using kp.Business;
using kp.ViewModels;
using kp.ViewModels.UserRoles;
using kp.ViewModels.Users;
using kp.Views;
using kp.Views.UserRoles;
using kp.Views.Users;
using WpfToolkit.Routing;
using kp.ViewModels.Login;
using kp.Views.Login;
using WpfToolkit.Services;

namespace kp
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{

			base.OnStartup(e);
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
		}
	}
}