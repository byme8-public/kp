﻿using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using WpfToolkit.Routing.Abstractions;

namespace kp.ViewModels.Core
{
    public class ViewModel : ReactiveObject
    {
    }

    public class ViewModel<TValue> : ViewModel, IViewModelWithValue<TValue>
    {
        [Reactive]
        public TValue Value
        {
            get;
            set;
        }

        object IViewModelWithValue.Value
        {
            get
            {
                return this.Value;
            }
            set
            {
                this.Value = (TValue)value;
            }
        }
    }
}