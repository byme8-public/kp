using System.Collections.Generic;
using System.Linq;
using kp.Business.Abstraction;
using kp.DataServies.Entities;
using kp.Resources;
using kp.ViewModels.Core;
using kp.Views.Core;
using ReactiveUI;

namespace kp.ViewModels
{
    public class UsersListViewModel : EntitiesViewModel<User>
    {
        public UsersListViewModel(IDataService<User> service, IDialogService dialogService)
            : base(service, dialogService)
        {
        }

        public override IEnumerable<MenuItemViewModel> CreateMenuItems()
        {
            var manageUserRoles = ReactiveCommand.Create(async () =>
            {
                if (!this.SelectedItems.Any())
                    return;

                var user = this.SelectedItems.First();
                await this.DialogService.ShowAsync<User>(Routes.UserRoleManagement, user);
            });

            return base.CreateMenuItems().
                Union(new[] 
                {
                    new MenuItemViewModel(Texts.ManageUserRoles, manageUserRoles)
                });
        }

        public override string EditDialog
            => "users/edit";

        public override string CreateDialog
            => "users/new";
    }
}