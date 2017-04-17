using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Business.Abstraction;
using kp.Domain.Data.Core;
using kp.Views.Core;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace kp.ViewModels.Core
{
    public abstract class EditEntityViewModel<TEntity> : ViewModel<TEntity>
        where TEntity : DomainEntity
    {
        public EditEntityViewModel(IDataService<TEntity> dataService, IDialogService dialogService)
        {
            this.DataService = dataService;
            this.Apply = ReactiveCommand.CreateFromTask(() => dataService.Update(this.Entity));
            this.Apply.Subscribe(_ => dialogService.Close(this.Entity));

            this.Cancel = ReactiveCommand.Create(() => dialogService.Close());

            this.WhenAnyValue(o => o.Value).
                Where(entity => entity != null).
                Subscribe(async entity => this.Entity = await dataService.GetById(entity.Id));
        }

        [Reactive]
        public TEntity Entity { get; set; }

        public IDataService<TEntity> DataService
        {
            get;
        }

        public ReactiveCommand<Unit, Unit> Cancel
        {
            get;
        }

        public ReactiveCommand<Unit, TEntity> Apply
        {
            get;
        }
    }
}