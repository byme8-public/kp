using DryIoc;
using kp.Business.Abstraction;
using kp.DataServies.Entities;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace kp.Business
{
	public static class RegisterServices
	{
		public static void AddDataServices(this IContainer services)
		{
			const string host = "http://localhost:5000/api";
			services.Register(typeof(IDataService<User>), made: Made.Of(() => RestService.For<IDataService<User>>(host + "/users")));
		}
	}
}
