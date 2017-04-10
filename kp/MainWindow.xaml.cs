using System.Windows;
using System.Windows.Controls;
using kp.Views.Core;
using WpfToolkit.Routing;
using WpfToolkit.Routing.Abstractions;
using System.Globalization;
using WpfToolkit.Services;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;

namespace kp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		public MainWindow()
		{
            CultureInfo.CurrentUICulture = new CultureInfo("ru-ru");

            this.InitializeComponent();

			var grid = new Grid();
			grid.Children.Add(Services.ServiceProvider.GetService<NavigationProvider>());
			grid.Children.Add(Services.ServiceProvider.GetService<IDialogService>() as DialogService);
			grid.Children.Add(Services.ServiceProvider.GetService<Snackbar>());
            this.Content = grid;

			Services.ServiceProvider.GetService<INavigator>().Navigate("login");
		}
	}
}