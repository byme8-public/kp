using System.Linq;
using System.Reflection;
using kp.Views.Core;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;
using WpfToolkit.Routing.Abstractions;

namespace kp.Views
{
    public static class RegisterViews
    {
        public static void AddViews(this IServiceCollection services)
        {
            var views = Assembly.GetEntryAssembly().
                                 GetTypes().
                                 Where(type => type.GetImplementedInterfaces().Contains(typeof(IView)));

            foreach (var view in views)
                services.AddScoped(view);

            services.AddSingleton<IDialogService, DialogService>();
            services.AddSingleton<ISnackbarMessageQueue>(new SnackbarMessageQueue());
            services.AddSingleton(s => new Snackbar
            {
                MessageQueue = s.GetService<ISnackbarMessageQueue>() as SnackbarMessageQueue
            });
        }
    }
}