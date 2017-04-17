using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Business.Abstraction;
using kp.Domain.Data;
using kp.ViewModels.Core;
using kp.Views.Core;

namespace kp.ViewModels.PaymentsKinds
{
    public class EditPaymentKindViewModel : EditEntityViewModel<PaymentKind>
    {
        public EditPaymentKindViewModel(IDataService<PaymentKind> dataService, IDialogService dialogService) 
            : base(dataService, dialogService)
        {
        }
    }
}
