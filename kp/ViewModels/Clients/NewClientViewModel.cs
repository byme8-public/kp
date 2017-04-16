using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Business.Abstraction;
using kp.Domain.Data;
using kp.ViewModels.Core;
using kp.Views.Core;
using ReactiveUI.Fody.Helpers;

namespace kp.ViewModels.Clients
{
    public class NewClientViewModel : NewEntityViewModel<Client>
    {
        public NewClientViewModel(IDataService<Client> service, IDialogService dialogService)
            : base(service, dialogService)
        {
        }

        [Reactive]
        public string FirstName
        {
            get;
            set;
        }

        [Reactive]
        public string LastName
        {
            get;
            set;
        }

        [Reactive]
        public string Surname
        {
            get;
            set;
        }

        [Reactive]
        public string Email
        {
            get;
            set;
        }

        protected override Client CreateEntity()
        {
            return new Client
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Surname = this.Surname,
                Email = this.Email
            };
        }
    }
}
