using MaterialDesignThemes.Wpf;
using ReactiveUI;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using kp.Resources;

namespace kp.Business.Exceptions
{
    public static class ExceptionHander
    {
        static ExceptionHander()
        {
            Messages = WpfToolkit.Services.Services.ServiceProvider.GetService<ISnackbarMessageQueue>();
        }

        public static ISnackbarMessageQueue Messages
        {
            get;
        }

        public static void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            switch (e.Exception)
            {
                case UnhandledErrorException unhandledError:
                    switch (unhandledError.InnerException)
                    {
                        case ApiException apiException:
                            switch (apiException.StatusCode)
                            {
                                case HttpStatusCode.BadRequest:
                                    Messages.Enqueue(apiException.Content);
                                    return;
                                case HttpStatusCode.InternalServerError:
                                    Messages.Enqueue(Texts.UnexpectedError);
                                    return;
                            }
                            return;
                    }
                    return;
            }
            e.Handled = false;
        }
    }
}
