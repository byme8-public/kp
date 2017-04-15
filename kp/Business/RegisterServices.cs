using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using kp.Business.Abstraction;
using kp.Business.DataServices;
using kp.Business.Entities;
using kp.Business.Services;
using kp.DataServies.Entities;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace kp.Business
{
    public static class RegisterServices
    {
        public static void AddDataServices(this IServiceCollection services)
        {
            const string host = "http://localhost:5000/api";
            var refitSettings = new RefitSettings
            {
                HttpMessageHandlerFactory = () => new HttpHandler()
            };
            services.AddSingleton(RestService.For<ITokenService>(host + "/tokens"));
            services.AddSingleton<IAuthorizationService, AuthorizationService>();
            services.AddSingleton(RestService.For<IUserService>(host + "/users", refitSettings));
            services.AddSingleton(RestService.For<IDataService<User>>(host + "/users", refitSettings));
            services.AddSingleton(RestService.For<IDataService<UserRole>>(host + "/users/roles", refitSettings));
        }

        private class HttpHandler : HttpClientHandler
        {
            public HttpHandler()
            {
                this.AuthorizationService = new Lazy<IAuthorizationService>(() => WpfToolkit.Services.Services.ServiceProvider.GetService<IAuthorizationService>());
            }

            public Lazy<IAuthorizationService> AuthorizationService
            {
                get;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                request.Headers.Add("UserToken", this.AuthorizationService.Value.UserToken);

                return base.SendAsync(request, cancellationToken);
            }
        }
    }
}