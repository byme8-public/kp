using System;
using System.Collections;
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
		public EntityListViewModel(IDataService<TEntity> service, INavigator navigator)
		{
			this.DataService = service;
			this.Entities = new ObservableCollection<TEntity>();
			this.LoadEntitiesAsync();

			this.New = ReactiveCommand.Create(() => navigator.Navigate(this.EntityCreationRoute));

			this.Edit = ReactiveCommand.Create<TEntity>(entity => navigator.Navigate(this.EntityEditingRoute, entity));

			this.Remove = ReactiveCommand.Create<IList>(async entities =>
			{
				foreach (var entity in entities.Cast<TEntity>().ToArray())
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

		public ReactiveCommand<IList, Unit> Remove
		{
			get;
		}

		public abstract string EntityEditingRoute
		{
			get;
		}

		public abstract string EntityCreationRoute
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
