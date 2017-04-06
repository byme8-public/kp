using System.Linq;
using System.Reflection;
using DryIoc;
using kp.Views.Core;
using kp.Views.Users;
using WpfToolkit.Routing.Abstractions;

namespace kp.Views
{
	public static class RegisterViews
	{
		public static void AddViews(this IContainer container)
		{
			var views = Assembly.GetEntryAssembly().
								 GetTypes().
								 Where(type => type.GetImplementedInterfaces().Contains(typeof(IView)));

			foreach (var view in views)
				container.Register(view);

			container.Register<IDialogService, DialogService>(Reuse.Singleton);
		}
	}
}