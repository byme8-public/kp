using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Business.Abstraction;
using kp.Business.Entities;
using kp.Resources;
using kp.ViewModels.Core;
using kp.Views.Core;

namespace kp.ViewModels.UserRoles
{
	[Export(typeof(UserRolesViewModel))]
	public class UserRolesViewModel : EntitiesViewModel<UserRole>
	{
		public UserRolesViewModel(IDataService<UserRole> service, IDialogService dialogService) 
			: base(service, dialogService)
		{
		}

		public override IEnumerable<MenuItemViewModel> CreateMenuItems()
		{
			var baseItems = base.CreateMenuItems().ToList();
			baseItems.RemoveAll(o => o.Header == Texts.Edit);

			return baseItems;
		}

		public override string CreateDialog 
			=> Routes.NewUserRole;

		public override string EditDialog 
			=> string.Empty;
	}
}
