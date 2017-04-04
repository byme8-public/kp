using DryIoc;
using kp.Views.Core;
using kp.Views.Users;

namespace kp.Views
{
	public static class RegisterViews
	{
		public static void AddViews(this IContainer container)
		{
			container.Register<IDialogService, DialogService>(Reuse.Singleton);
			container.Register<UsersView>();
			container.Register<NewUserView>();
			container.Register<EditUserView>();
		}
	}
}