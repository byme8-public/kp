using kp.Business.Abstraction;
using kp.DataServies.Entities;
using kp.ViewModels.Core;
using kp.Views.Core;
using WpfToolkit.Routing.Abstractions;

namespace kp.ViewModels
{
	public class UsersListViewModel : EntitiesViewModel<User>
	{
		public UsersListViewModel(IDataService<User> service, IDialogService dialogService)
			: base(service, dialogService)
		{
		}

		public override string EditDialog
			=> "users/edit";

		public override string CreateDialog
			=> "users/new";
	}
}