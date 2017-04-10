using System.Threading.Tasks;
using kp.Business.Exceptions;
using MaterialDesignThemes.Wpf;
using WpfToolkit.Routing.Abstractions;

namespace kp.Views.Core
{
    public class DialogService : DialogHost, IDialogService
    {
        private class DialogCanceled
        {
            public static DialogCanceled Default { get; } = new DialogCanceled();
        }

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
            CloseDialogCommand?.Execute(DialogCanceled.Default, this);
        }

        public void Close(object result)
        {
            CloseDialogCommand?.Execute(result, this);
        }

        public async Task ShowAsync(string dialog)
        {
            var view = this.ViewResolver.ResolveView(dialog);
            var result = await Show(view);
            if (result is DialogCanceled)
            {
                throw new ActionCanceledException("Dialog was canceled.");
            }
        }

        public async Task<TResult> ShowAsync<TResult>(string dialog)
        {
            var view = this.ViewResolver.ResolveView(dialog);
            var result = await Show(view);
            if (result is DialogCanceled)
            {
                throw new ActionCanceledException("Dialog was canceled.");
            }
            return (TResult)result;
        }

        public async Task<TResult> ShowAsync<TResult>(string dialog, object value)
        {
            var view = this.ViewResolver.ResolveView(dialog);
            if (view.DataContext is IViewModelWithValue viewModelWithValue)
            {
                viewModelWithValue.Value = value;
            }

            var result = await Show(view);
            if (result is DialogCanceled)
            {
                throw new ActionCanceledException("Dialog was canceled.");
            }

            return (TResult)result;
        }
    }
}