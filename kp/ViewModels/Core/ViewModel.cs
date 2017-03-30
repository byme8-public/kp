using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace kp.ViewModels.Core
{
	public class ViewModel : ReactiveObject
	{
	}

	public class ViewModel<TValue> : ReactiveObject
	{
		[Reactive]
		public TValue Value
		{
			get;
			set;
		}
	}
}
