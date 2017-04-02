using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;
using WpfToolkit.Routing.Abstractions;
using WPFToolkit.Routing.Abstractions;

namespace kp.Views.Core
{
	public class DialogService : IDialogService
	{
		public DialogService(IViewResolver viewResolver)
		{
			this.ViewResolver = viewResolver;
		}

		public IViewResolver ViewResolver
		{
			get;
		}

		public IView Resolve(string dialogName)
		{
			return this.ViewResolver.ResolveView(dialogName);
		}

		public async Task<bool> ShowAsync(string dialogName)
		{
			var view = this.Resolve(dialogName);
			return await this.ShowAsync(view);
		}

		public async Task<bool> ShowAsync(IView view)
		{
			return (bool)await DialogHost.Show(view);
		}
	}
}
