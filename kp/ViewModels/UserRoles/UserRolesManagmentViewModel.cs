using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Business.Abstraction;
using kp.Business.DataServices;
using kp.Domain.Data;
using kp.ViewModels.Core;
using kp.Views.Core;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace kp.ViewModels.UserRoles
{
    //TODO: Make proposal to ReactiveUI
    public static class ReactivePropertyChangedExtention
    {
        public static IObservable<TResult> WhenPropertyChanged<TReactiveObject, TResult>(
            this TReactiveObject reactiveObject, 
            Expression<Func<TReactiveObject, TResult>> expression)
            where TReactiveObject : ReactiveObject
        {
            return reactiveObject.WhenAnyValue(expression).Skip(1);
        }
    }

    public class UserRolesManagmentViewModel : DialogViewModel<User>
    {
        public UserRolesManagmentViewModel(IUserService userService, IDataService<Role> userRolesService, IDialogService dialogService)
            : base(dialogService)
        {
            this.WhenAnyValue(o => o.Value).Subscribe(async user =>
            {
                var roles = await userRolesService.GetAll();
                this.Roles = roles.Select(o => new SelectableViewModel<Role>(o)).ToArray();
                foreach (var role in this.Roles)
                {
                    if (this.Value.Roles.Any(o => o.Id == role.Value.Id))
                        role.IsSelected = true;

                    role.WhenPropertyChanged(o => o.IsSelected).Subscribe(value =>
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
        public IEnumerable<SelectableViewModel<Role>> Roles
        {
            get;
            private set;
        }
    }
}
