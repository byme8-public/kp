using System.ComponentModel.Composition;
using kp.Business.Abstraction;
using kp.Domain.Data;
using kp.ViewModels.Core;
using kp.Views.Core;

namespace kp.ViewModels.Clients
{
    public class EditClientViewModel : EditEntityViewModel<Client>
    {
        public EditClientViewModel(IDataService<Client> dataService, IDialogService dialogService) 
            : base(dataService, dialogService)
        {
        }
    }
}
