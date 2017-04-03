using System;
using System.Reactive.Linq;
using System.Reactive;
using kp.Business.Abstraction;
using kp.DataServies.Entities;
using kp.ViewModels.Core;
using ReactiveUI;
using WpfToolkit.Routing.Abstractions;
using ReactiveUI.Fody.Helpers;

namespace kp.ViewModels.Users
{
	public class EditUserViewModel : ViewModel<User>
	{
		public EditUserViewModel(IDataService<User> dataService, INavigator navigator)
		{
			this.Apply = ReactiveCommand.CreateFromTask(() => dataService.Update(this.Value));
			this.Apply.Subscribe(_ => this.GoToUsers(navigator));

			this.Cancel = ReactiveCommand.Create(() => this.GoToUsers(navigator));

			this.WhenAnyValue(o => o.Value).
				Subscribe(_ => this.RaisePropertyChanged(nameof(this.Login)));
		}

		private void GoToUsers(INavigator navigator)
		{
			navigator.Navigate("users");
		}

		public string Login
		{
			get
			{
				return this.Value?.Login;
			}
			set
			{
				if (this.Login == value)
				{
					return;
				}

				this.Value.Login = value;
				this.RaisePropertyChanged();
			}
		}

		public ReactiveCommand<Unit, User> Apply
		{
			get;
		}

		public ReactiveCommand<Unit, Unit> Cancel
		{
			get;
		}
	}
}
