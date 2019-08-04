using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TFTHelper2.Client.ViewModels
{
    public class StartViewViewModel : ViewModelBase
    {
        public event Action Continued;

        public StartViewViewModel()
        {
            ContinueToAppCommand = new RelayCommandAsync(ContinueToApp);
        }

        public ICommand ContinueToAppCommand { get; set; }
        private async Task ContinueToApp(object x)
        {
            Continued?.Invoke();
        }
    }
}
