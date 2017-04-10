using System.Net;
using kp.Resources;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using Refit;

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