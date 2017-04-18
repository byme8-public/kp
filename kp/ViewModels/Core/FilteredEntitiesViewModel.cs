using System;
using kp.Business.Abstraction;
using kp.Domain.Data.Core;
using kp.Views.Core;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace kp.ViewModels.Core
{
    public abstract class FilteredEntitiesViewModel<TEntity> : EntitiesViewModel<TEntity>
        where TEntity : DomainEntity
    {
        public FilteredEntitiesViewModel(IDataService<TEntity> service, IDialogService dialogService)
            : base(service, dialogService)
        {
            this.WhenAnyValue(o => o.Value).
                Subscribe(_ => this.Initialize());
        }

        protected abstract void Initialize();

        [Reactive]
        public TEntity Value
        {
            get;
            set;
        }
    }
}
