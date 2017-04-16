using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Business.Abstraction;
using kp.Domain.Data;
using kp.ViewModels.Core;
using kp.Views.Core;

namespace kp.ViewModels.Clients
{
    public class ClientsViewModel : EntitiesViewModel<Client>
    {
        public ClientsViewModel(IDataService<Client> service, IDialogService dialogService) 
            : base(service, dialogService)
        {
        }

        public override string CreateDialog
            => "client/new";

        public override string EditDialog
            => "client/edit";
    }
}
