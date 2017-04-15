using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI.Fody.Helpers;

namespace kp.ViewModels.Core
{
    public class SelectableViewModel<TValue> : ViewModel<TValue>
    {
        public SelectableViewModel(TValue value)
        {
            this.Value = value;
        }

        [Reactive]
        public bool IsSelected
        {
            get;
            set;
        }
    }
}
