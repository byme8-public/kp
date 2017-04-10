using kp.Business.Abstraction;
using kp.Business.Entities;
using kp.ViewModels.Core;
using kp.Views.Core;
using ReactiveUI.Fody.Helpers;

namespace kp.ViewModels.UserRoles
{
    public class NewUserRoleViewModel : NewEntityViewModel<UserRole>
    {
        public NewUserRoleViewModel(IDataService<UserRole> service, IDialogService dialogService)
            : base(service, dialogService)
        {
        }

        [Reactive]
        public string Name
        {
            get;
            set;
        }

        protected override UserRole CreateEntity()
            => new UserRole
            {
                Name = this.Name
            };
    }
}