using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DryIoc;
using kp.ViewModels.Users;

namespace kp.ViewModels
{
	public static class RegisterViewModels
	{
		public static void AddViewModels(this IContainer container)
		{
			container.Register<UsersListViewModel>();
			container.Register<NewUserViewModel>();
		}
	}
}
