using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using kp.Business.Abstraction;
using kp.DataServies.Entities;
using kp.ViewModels.Core;
using MaterialDesignThemes.Wpf;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using WpfToolkit.Routing.Abstractions;

namespace kp.ViewModels.Users
{
	//TODO: Add validation
	public class NewUserViewModel : ViewModel
	{
		public NewUserViewModel(IDataService<User> userService, INavigator navigator)
		{
			this.Create = ReactiveCommand.Create(async () =>
			{
				await userService.Add(new User { Login = this.Login, Password = this.Password });
				navigator.Navigate("users");
			});

			this.Cancel = ReactiveCommand.Create(() => navigator.Navigate("users"));
		}

		[Reactive]
		public string Login
		{
			get;
			set;
		}

		[Reactive]
		public string Password
		{
			get;
			set;
		}

		public ReactiveCommand<Unit, Task> Create
		{
			get;
		}

		public ReactiveCommand<Unit, Unit> Cancel
		{
			get;
		}
	}
}
