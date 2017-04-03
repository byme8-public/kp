using System.Windows;
using kp.Business;
using kp.DataServies.Entities;
using kp.ViewModels;
using kp.ViewModels.Core;
using kp.ViewModels.Users;
using kp.Views;
using kp.Views.Core;
using kp.Views.Users;
using Microsoft.Extensions.DependencyInjection;
using WpfToolkit.Forms.Toolkit.Services;
using WpfToolkit.Routing;

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
				routes.Add<UsersView, UsersListViewModel>("users");
				routes.Add<NewUserView, NewUserViewModel>("users/new");
				routes.Add<EditUserView, EditUserViewModel>("users/edit");
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
