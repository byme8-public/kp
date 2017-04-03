using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfToolkit.Forms.Toolkit.Services;
using WpfToolkit.Routing.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using WpfToolkit.Routing;
using MaterialDesignThemes.Wpf;

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

			var navigator = Services.Resolver.Resolve(typeof(INavigator), false) as INavigator;

			var grid = new Grid();
			grid.Children.Add(new NavigationProvider(navigator));
			grid.Children.Add(new DialogHost());
			this.Content = grid;

			navigator.Navigate("users");
		}
	}
}
