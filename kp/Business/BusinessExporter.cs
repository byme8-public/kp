using kp.Business.Abstraction;
using kp.Business.DataServices;
using kp.Business.Factories.Core;
using kp.DataServies.Entities;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace kp.Business
{
	public static class BusinessExporter
	{
		public static void AddDataServices(this IServiceCollection services)
		{
			var host = "http://localhost:5000/api";

			services.AddSingleton(typeof(IEntityFactory<>), typeof(EntityFactory<>));
			services.AddSingleton(_ => RestService.For<IEntityService<User>>(host + "/users"));
		}
	}
}
