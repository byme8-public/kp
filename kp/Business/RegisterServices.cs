using DryIoc;
using kp.Business.Abstraction;
using kp.Business.DataServices;
using kp.Business.Entities;
using kp.Business.Services;
using kp.DataServies.Entities;
using Refit;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Threading;

namespace kp.Business
{
    public static class RegisterServices
    {
        public static void AddDataServices(this IContainer services)
        {
            const string host = "http://localhost:5000/api";
            var refitSettings = new RefitSettings
            {
                HttpMessageHandlerFactory = () => new HttpHandler()
            };
            services.Register(typeof(ITokenService), made: Made.Of(() => RestService.For<ITokenService>(host + "/tokens")));
            services.Register<IAuthorizationService, AuthorizationService>(Reuse.Singleton);
            services.Register(made: Made.Of(() => RestService.For<IDataService<User>>(host + "/users", refitSettings)));
            services.Register(made: Made.Of(() => RestService.For<IDataService<UserRole>>(host + "/users/roles", refitSettings)));
        }


        class HttpHandler : HttpClientHandler
        {
            public HttpHandler()
            {
                this.AuthorizationService = WpfToolkit.Services.Services.Resolver.Resolve<IAuthorizationService>();
            }

            public IAuthorizationService AuthorizationService
            {
                get;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                request.Headers.Add("UserToken", this.AuthorizationService.UserToken);
                
                return base.SendAsync(request, cancellationToken);
            }
        }
    }
}