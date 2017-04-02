﻿using System;
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
		public UsersListViewModel(IDataService<User> service, IDialogService dialogService, INavigator navigator) 
			: base(service, dialogService, navigator)
		{
		}

		public override string EditDialogName 
			=> "users/edit";
	}
}