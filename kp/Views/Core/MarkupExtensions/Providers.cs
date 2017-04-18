using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using WpfToolkit.Routing;
using WpfToolkit.Services;
using Microsoft.Extensions.DependencyInjection;

namespace kp.Views.Core.MarkupExtensions
{
    public class NavigationProvider : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Services.ServiceProvider.GetService<WpfToolkit.Routing.NavigationProvider>();
        }
    }

    public class DialogService : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var a = Services.ServiceProvider.GetService<IDialogService>() as Core.DialogService;
            return a;
        }
    }

    public class Snackbar : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Services.ServiceProvider.GetService<MaterialDesignThemes.Wpf.Snackbar>();
        }
    }
}
