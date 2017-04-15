using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using kp.Business.Abstraction;
using kp.Domain.Data;
using kp.Resources;
using kp.ViewModels.Core;
using kp.Views.Core;

namespace kp.ViewModels.UserRoles
{
    [Export(typeof(UserRolesViewModel))]
    public class UserRolesViewModel : EntitiesViewModel<Role>
    {
        public UserRolesViewModel(IDataService<Role> service, IDialogService dialogService)
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