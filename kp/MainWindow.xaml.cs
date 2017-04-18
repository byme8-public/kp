using kp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
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
            this.InitializeComponent();
            this.DataContext = Services.ServiceProvider.GetService<MainWindowViewModel>();
        }
    }
}