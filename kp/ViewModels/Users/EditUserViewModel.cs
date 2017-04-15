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
    public class EditUserViewModel : ViewModel<User>
    {
        public EditUserViewModel(IDataService<User> dataService, IDialogService dialogService)
        {
            this.DataService = dataService;
            this.Apply = ReactiveCommand.CreateFromTask(() => dataService.Update(this.Entity));
            this.Apply.Subscribe(_ => dialogService.Close(this.Entity));

            this.Cancel = ReactiveCommand.Create(() => dialogService.Close());

            this.WhenAnyValue(o => o.Entity).
                Subscribe(_ => this.RaisePropertyChanged(nameof(this.Login)));

            this.WhenAnyValue(o => o.Value).
                Where(entity => entity != null).
                Subscribe(async entity => this.Entity = await dataService.GetById(entity.Id));
        }

        public string Login
        {
            get
            {
                return this.Entity?.Login;
            }
            set
            {
                if (this.Login == value)
                {
                    return;
                }

                this.Entity.Login = value;
                this.RaisePropertyChanged();
            }
        }

        public ReactiveCommand<Unit, User> Apply
        {
            get;
        }

        public ReactiveCommand<Unit, Unit> Cancel
        {
            get;
        }

        [Reactive]
        public User Entity
        {
            get;
            set;
        }

        public IDataService<User> DataService
        {
            get;
        }
    }
}