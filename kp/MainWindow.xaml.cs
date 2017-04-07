using System.Windows;
using System.Windows.Controls;
using kp.Views.Core;
using WpfToolkit.Forms.Toolkit.Services;
using WpfToolkit.Routing;
using WpfToolkit.Routing.Abstractions;

namespace kp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			this.InitializeComponent();

			var grid = new Grid();
			grid.Children.Add(Services.Resolver.Resolve(typeof(NavigationProvider), false) as NavigationProvider);
			grid.Children.Add(Services.Resolver.Resolve(typeof(IDialogService), false) as DialogService);
			this.Content = grid;

			(Services.Resolver.Resolve(typeof(INavigator), false) as INavigator).Navigate(kp.Resources.Routes.Users);
		}
	}
}