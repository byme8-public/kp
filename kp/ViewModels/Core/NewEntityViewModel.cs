using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using kp.Business.Abstraction;
using kp.DataServies.Entities.Core;
using kp.Views.Core;
using ReactiveUI;

namespace kp.ViewModels.Core
{
	public abstract class NewEntityViewModel<TEntity> : ViewModel
		where TEntity : Entity
	{
		public NewEntityViewModel(IDataService<TEntity> service, IDialogService dialogService)
		{
			this.Create = ReactiveCommand.CreateFromTask(() => service.Add(this.CreateEntity()));
			this.Create.Subscribe(entity => dialogService.Close(entity));

			this.Cancel = ReactiveCommand.Create(() => dialogService.Close());
		}

		protected abstract TEntity CreateEntity();

		public ReactiveCommand<Unit, TEntity> Create
		{
			get;
		}

		public ReactiveCommand<Unit, Unit> Cancel
		{
			get;
		}
	}
}
