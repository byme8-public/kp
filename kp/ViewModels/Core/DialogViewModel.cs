using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using kp.Views.Core;
using ReactiveUI;

namespace kp.ViewModels.Core
{
    public class DialogViewModel<TValue> : ViewModel<TValue>
    {
        public DialogViewModel(IDialogService dialogService)
        {
            this.DialogService = dialogService;

            this.Close = ReactiveCommand.Create(() => dialogService.Close());
        }

        public IDialogService DialogService
        {
            get;
        }

        public ReactiveCommand<Unit, Unit> Close
        {
            get;
        }
    }
}
