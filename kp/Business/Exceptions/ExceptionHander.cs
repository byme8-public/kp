using System.Net;
using System.Net.Sockets;
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
            var exception = e.Exception;
            while (exception.InnerException != null)
                exception = exception.InnerException;

            switch (exception)
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
                case SocketException soketException:
                    Messages.Enqueue(Texts.ProblemWithConnection);
                    return;
            }
            e.Handled = false;
        }
    }
}