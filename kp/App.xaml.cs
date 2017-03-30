using System.Windows;
using kp.Business;
using kp.DataServies.Entities;
using kp.ViewModels.Core;
using kp.Views;
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
				routes.Add<UsersView, EntityListViewModel<User>>("users");
			});

			Services.Configure(services =>
			{
				services.AddRouting();
				services.AddDataServices();
			});
		}
	}
}
