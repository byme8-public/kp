using System.Threading.Tasks;

namespace kp.Views.Core
{
    public interface IDialogService
    {
        Task ShowAsync(string dialog);

        Task<TResult> ShowAsync<TResult>(string dialog);

        Task<TResult> ShowAsync<TResult>(string dialog, object value);

        void Close();

        void Close(object result);
    }
}