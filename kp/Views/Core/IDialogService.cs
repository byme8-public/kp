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
		IView Resolve(string dialogName);
		Task<bool> ShowAsync(string dialogName);
		Task<bool> ShowAsync(IView view);
	}
}
