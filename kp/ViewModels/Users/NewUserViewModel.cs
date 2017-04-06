using System;
using System.Reactive;
using kp.Business.Abstraction;
using kp.DataServies.Entities;
using kp.ViewModels.Core;
using kp.Views.Core;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using WpfToolkit.Routing.Abstractions;

namespace kp.ViewModels.Users
{
	//TODO: Add validation
	public class NewUserViewModel : NewEntityViewModel<User>
	{
		public NewUserViewModel(IDataService<User> userService, IDialogService dialogService)
			: base(userService, dialogService)
		{
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

		protected override User CreateEntity()
			=> new User
			{
				Login = this.Login,
				Password = this.Password
			};
	}
}