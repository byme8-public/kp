using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Business.Abstraction;
using kp.Business.DataServices;
using kp.Business.Entities;
using kp.DataServies.Entities;
using kp.ViewModels.Core;
using kp.Views.Core;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace kp.ViewModels.UserRoles
{
    public class UserRolesManagmentViewModel : DialogViewModel<User>
    {
        public UserRolesManagmentViewModel(IUserService userService, IDataService<UserRole> userRolesService, IDialogService dialogService)
            : base(dialogService)
        {
            this.WhenAnyValue(o => o.Value).Subscribe(async user =>
            {
                var roles = await userRolesService.GetAll();
                this.Roles = roles.Select(o => new SelectableViewModel<UserRole>(o)).ToArray();
                foreach (var role in this.Roles)
                {
                    if (this.Value.Roles.Any(o => o.Id == role.Value.Id))
                        role.IsSelected = true;

                    role.WhenAnyValue(o => o.IsSelected).Skip(1).Subscribe(value =>
                    {
                        if (value)
                        {
                            userService.AddRole(this.Value.Id, role.Value.Id);
                            this.Value.Roles.Add(role.Value);
                        }
                        else
                        {
                            userService.RemoveRole(this.Value.Id, role.Value.Id);
                            this.Value.Roles.Remove(role.Value);
                        }
                    });
                }
            });
        }

        [Reactive]
        public IEnumerable<SelectableViewModel<UserRole>> Roles
        {
            get;
            private set;
        }
    }
}
