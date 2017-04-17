using System;
using System.Reactive;
using System.Reactive.Linq;
using kp.Business.Abstraction;
using kp.Domain.Data;
using kp.ViewModels.Core;
using kp.Views.Core;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace kp.ViewModels.Users
{
    public class EditUserViewModel : EditEntityViewModel<User>
    {
        public EditUserViewModel(IDataService<User> dataService, IDialogService dialogService)
            :base(dataService, dialogService)
        {
        }
    }
}