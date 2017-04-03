using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Business.Abstraction;
using kp.DataServies.Entities;
using kp.ViewModels.Core;
using kp.Views.Core;
using WpfToolkit.Routing.Abstractions;

namespace kp.ViewModels
{
	public class UsersListViewModel : EntityListViewModel<User>
	{
		public UsersListViewModel(IDataService<User> service, INavigator navigator) 
			: base(service, navigator)
		{
		}

		public override string EntityEditingRoute 
			=> "users/edit";

		public override string EntityCreationRoute
			=> "users/new";
	}
}
