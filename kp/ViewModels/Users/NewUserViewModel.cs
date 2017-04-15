using kp.Business.Abstraction;
using kp.Domain.Data;
using kp.ViewModels.Core;
using kp.Views.Core;
using ReactiveUI.Fody.Helpers;

namespace kp.ViewModels.Users
{
    //TODO: Add validation
    public class NewUserViewModel : NewEntityViewModel<User>
    {
        public NewUserViewModel(IDataService<User> userService, IDialogService dialogService)
            : base(userService, dialogService)
        {
        }

        [Reactive]
        public string Login
        {
            get;
            set;
        }

        [Reactive]
        public string Password
        {
            get;
            set;
        }

        protected override User CreateEntity()
            => new User
            {
                Login = this.Login,
                Password = this.Password
            };
    }
}