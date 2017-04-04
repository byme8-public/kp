using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;
using WPFToolkit.Routing.Abstractions;

namespace kp.Views.Core
{
	public class DialogService : DialogHost, IDialogService
	{
		public DialogService(IViewResolver viewResolver)
		{
			this.ViewResolver = viewResolver;
		}

		public IViewResolver ViewResolver
		{
			get;
		}

		public void Close()
		{
			CloseDialogCommand?.Execute(null, this);
		}

		public void Close(object result)
		{
			CloseDialogCommand?.Execute(result, this);
		}

		public async Task ShowAsync(string dialog)
		{
			var view = this.ViewResolver.ResolveView(dialog);
			await Show(view);
		}

		public async Task<TResult> ShowAsync<TResult>(string dialog)
		{
			var view = this.ViewResolver.ResolveView(dialog);
			var result = (TResult)await Show(view);
			return result;
		}

		public async Task<TResult> ShowAsync<TResult>(string dialog, object value)
		{
			var view = this.ViewResolver.ResolveView(dialog);
			if (view.DataContext is IViewModelWithValue viewModelWithValue)
			{
				viewModelWithValue.Value = value;
			}

			var result = (TResult)await Show(view);
			return result;
		}
	}
}