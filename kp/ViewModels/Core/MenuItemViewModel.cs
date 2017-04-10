using System.Windows.Input;

namespace kp.ViewModels.Core
{
    public class MenuItemViewModel : ViewModel
    {
        public MenuItemViewModel(string header, ICommand command)
        {
            this.Header = header;
            this.Command = command;
        }

        public ICommand Command
        {
            get;
        }

        public string Header
        {
            get;
        }
    }
}