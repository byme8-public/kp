using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfToolkit.Routing.Abstractions;

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
