using kp.Business.Abstraction;
using kp.Domain.Data;
using kp.ViewModels.Core;
using kp.Views.Core;
using ReactiveUI.Fody.Helpers;

namespace kp.ViewModels.UserRoles
{
    public class NewUserRoleViewModel : NewEntityViewModel<Role>
    {
        public NewUserRoleViewModel(IDataService<Role> service, IDialogService dialogService)
            : base(service, dialogService)
        {
        }

        [Reactive]
        public string Name
        {
            get;
            set;
        }

        protected override Role CreateEntity()
            => new Role
            {
                Name = this.Name
            };
    }
}