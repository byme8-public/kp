using System.Globalization;
using System.Windows.Controls;
using kp.Business.Abstraction;
using kp.Views.Core;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;
using WpfToolkit.Routing;
using WpfToolkit.Routing.Abstractions;
using WpfToolkit.Services;

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
        }
    }
}