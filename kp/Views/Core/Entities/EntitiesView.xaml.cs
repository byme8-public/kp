using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using kp.DataServies.Entities.Core;
using kp.ViewModels.Core;

namespace kp.Views.Core.Entities
{
	/// <summary>
	/// Interaction logic for EntitiesView.xaml
	/// </summary>
	public partial class EntitiesView : UserControl
	{
		public EntitiesView()
		{
			this.InitializeComponent();
			this.Items.SelectionChanged += this.Items_SelectionChanged;
			this.DataContextChanged += this.EntitiesView_DataContextChanged;
		}

		private void EntitiesView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			this.ViewModel = e.NewValue as EntitiesViewModel;
		}

		private void Items_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			foreach (var newItem in e.AddedItems)
				this.ViewModel?.SelectedItems.Add(newItem);

			foreach (var oldItem in e.RemovedItems)
				this.ViewModel?.SelectedItems.Remove(oldItem);
		}

		public ObservableCollection<DataGridColumn> Columns
		{
			get
			{
				return this.Items.Columns;
			}
			set
			{
				this.Items.Columns.Clear();
				foreach (var item in value)
				{
					this.Items.Columns.Add(item);
				}
			}
		}

		private EntitiesViewModel ViewModel
		{
			get;
			set;
		}
	}
}
