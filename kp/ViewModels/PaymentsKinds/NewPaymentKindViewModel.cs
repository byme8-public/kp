using kp.Business.Abstraction;
using kp.Domain.Data;
using kp.ViewModels.Core;
using kp.Views.Core;
using ReactiveUI.Fody.Helpers;

namespace kp.ViewModels.PaymentsKinds
{
    public class NewPaymentKindViewModel : NewEntityViewModel<PaymentKind>
    {
        public NewPaymentKindViewModel(IDataService<PaymentKind> service, IDialogService dialogService)
            : base(service, dialogService)
        {
        }

        [Reactive]
        public string Name
        {
            get;
            set;
        }

        protected override PaymentKind CreateEntity()
        {
            return new PaymentKind
            {
                Name = this.Name
            };
        }
    }
}
