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
    public class PaymentsKindViewModel : EntitiesViewModel<PaymentKind>
    {
        public PaymentsKindViewModel(IDataService<PaymentKind> service, IDialogService dialogService) 
            : base(service, dialogService)
        {
        }

        public override string CreateDialog => "paymentKinds/new";

        public override string EditDialog => "paymentKinds/edit";
    }
}
