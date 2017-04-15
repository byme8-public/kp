using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using kp.Business.Abstraction;
using kp.Business.Exceptions;
using kp.Domain.Data.Core;
using kp.Resources;
using kp.Views.Core;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace kp.ViewModels.Core
{
    public class EntitiesViewModel : ViewModel
    {
        public EntitiesViewModel()
        {
            this.SelectedItems = new ObservableCollection<object>();
        }

        [Reactive]
        public ObservableCollection<object> SelectedItems
        {
            get;
            set;
        }
    }

    public abstract class EntitiesViewModel<TEntity> : EntitiesViewModel
        where TEntity : DomainEntity
    {
        public EntitiesViewModel(IDataService<TEntity> service, IDialogService dialogService)
        {
            this.DataService = service;
            this.DialogService = dialogService;

            this.Entities = new ObservableCollection<TEntity>();
            this.LoadEntitiesAsync();

            this.MenuItems = this.CreateMenuItems();
        }

        public abstract string CreateDialog
        {
            get;
        }

        public IDataService<TEntity> DataService
        {
            get;
        }

        public IDialogService DialogService
        {
            get;
        }

        public abstract string EditDialog
        {
            get;
        }

        public ObservableCollection<TEntity> Entities
        {
            get;
        }

        public IEnumerable<MenuItemViewModel> MenuItems
        {
            get;
        }

        public virtual IEnumerable<MenuItemViewModel> CreateMenuItems()
        {
            var newCommand = ReactiveCommand.CreateFromTask(() => this.DialogService.ShowAsync<TEntity>(this.CreateDialog));
            newCommand.ThrownExceptions.OfType<ActionCanceledException>().Subscribe();
            newCommand.Subscribe(entity => this.Entities.Add(entity));

            var editCommand = ReactiveCommand.CreateFromTask(() =>
            {
                if (this.SelectedItems.Any())
                    return this.DialogService.ShowAsync<TEntity>(this.EditDialog, this.SelectedItems.First());

                throw new ActionCanceledException("Selected items is empty.");
            });
            editCommand.ThrownExceptions.OfType<ActionCanceledException>().Subscribe();
            editCommand.Subscribe(entity =>
            {
                for (int i = 0; i < this.Entities.Count; i++)
                {
                    if (this.Entities[i].Id == entity.Id)
                    {
                        this.Entities[i] = entity;
                        return;
                    }
                }
            });

            var removeCommmand = ReactiveCommand.CreateFromTask(async () =>
            {
                foreach (var entity in this.SelectedItems.Cast<TEntity>().ToArray())
                {
                    await this.DataService.Remove(entity.Id);
                    this.Entities.Remove(entity);
                }
            });

            return new[] {
                new MenuItemViewModel(Texts.New, newCommand),
                new MenuItemViewModel(Texts.Edit, editCommand),
                new MenuItemViewModel(Texts.Remove, removeCommmand) };
        }

        private async void LoadEntitiesAsync()
        {
            var entities = await this.DataService.GetAll();

            this.Entities.Clear();
            foreach (var entity in entities)
            {
                this.Entities.Add(entity);
            }
        }
    }
}