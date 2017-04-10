using System.Linq;
using System.Reflection;
using DryIoc;
using kp.Views.Core;
using kp.Views.Users;
using WpfToolkit.Routing.Abstractions;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;

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