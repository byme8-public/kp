using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Business.Abstraction;
using kp.DataServies.Entities.Core;
using kp.ViewModels.Core.Abstractions;
using kp.Views.Core;
using ReactiveUI;
using WpfToolkit.Routing.Abstractions;

namespace kp.ViewModels.Core
{
	public abstract class EntityListViewModel<TEntity> : ViewModel
		where TEntity : Entity
	{
		public EntityListViewModel(IDataService<TEntity> service, IDialogService dialogService, INavigator navigator)
		{
			this.DataService = service;
			this.Entities = new ObservableCollection<TEntity>();
			this.LoadEntitiesAsync();

			this.New = ReactiveCommand.Create(() => navigator.Navigate("users/new"));

			this.Edit = ReactiveCommand.Create<TEntity>(async entity =>
			{
				var view = dialogService.Resolve(this.EditDialogName);
				var editViewModel = view.DataContext as IEditViewModel<TEntity>;
				editViewModel.Entity = entity;

				if(await dialogService.ShowAsync(view))
					this.LoadEntitiesAsync();
			});

			this.Remove = ReactiveCommand.Create<IEnumerable<TEntity>>(async entities =>
			{
				foreach (var entity in entities)
				{
					await this.DataService.Remove(entity.Id);
					this.Entities.Remove(entity);
				}
			});
		}

		public ObservableCollection<TEntity> Entities
		{
			get;
		}

		public IDataService<TEntity> DataService
		{
			get;
		}

		public ReactiveCommand<IEnumerable<TEntity>, Unit> Remove
		{
			get;
		}

		public abstract string EditDialogName
		{
			get;
		}

		public ReactiveCommand<TEntity, Unit> Edit
		{
			get;
		}
		public ReactiveCommand<Unit, Unit> New { get; private set; }

		private async void LoadEntitiesAsync()
		{
			var entities = await this.DataService.Get();

			this.Entities.Clear();
			foreach (var entity in entities)
			{
				this.Entities.Add(entity);
			}
		}
	}
}
