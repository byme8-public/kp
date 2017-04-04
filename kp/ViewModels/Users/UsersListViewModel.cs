using kp.Business.Abstraction;
using kp.DataServies.Entities;
using kp.ViewModels.Core;
using kp.Views.Core;
using WpfToolkit.Routing.Abstractions;

namespace kp.ViewModels
{
	public class UsersListViewModel : EntityListViewModel<User>
	{
		public UsersListViewModel(IDataService<User> service, INavigator navigator, IDialogService dialogService)
			: base(service, navigator, dialogService)
		{
		}

		public override string EntityEditingRoute
			=> "users/edit";

		public override string EntityCreationDialog
			=> "users/new";
	}
}