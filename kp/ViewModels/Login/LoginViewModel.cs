using kp.ViewModels.Core;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kp.ViewModels.Login
{
    public class LoginViewModel : ViewModel
    {
        [Reactive]
        public string Login
        {
            get;
            set;
        }

        [Reactive]
        public string Password
        {
            get;
            set;
        }
    }
}
