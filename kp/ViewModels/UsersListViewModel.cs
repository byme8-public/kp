using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Business.Abstraction;
using kp.DataServies.Entities;
using kp.ViewModels.Core;
using kp.Views.Core;

namespace kp.ViewModels
{
	public class UsersListViewModel : EntityListViewModel<User>
	{
		public UsersListViewModel(IDataService<User> service, IDialogService dialogService, IEntityFactory<User> factory) 
			: base(service, dialogService, factory)
		{
		}

		public override string EditDialogName 
			=> "users/edit";
	}
}
