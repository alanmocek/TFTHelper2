using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFTHelper2.Application.ApiReader;


using Ninject;
using TFTHelper2.Application.Champions;
using TFTHelper2.Application.Champions.Classes;
using System.Windows.Input;
using TFTHelper2.Application.Items;

namespace TFTHelper2.Client.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly StartViewViewModel _startViewViewModel;
        private readonly PrimaryViewViewModel _primaryViewViewModel;

        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => currentViewModel;
            set
            {
                currentViewModel = value;
                UpdateProperty(nameof(CurrentViewModel));
            }
        }

        public MainViewModel()
        {
            _startViewViewModel = new StartViewViewModel();
            _startViewViewModel.Continued += OnContinued;

            _primaryViewViewModel = new PrimaryViewViewModel();

            CurrentViewModel = _startViewViewModel;

            // to remove

            costam();
        }

        private void OnContinued()
        {
            CurrentViewModel = _primaryViewViewModel;
        }

        private async Task costam()
        {
            await Bootstraper.Kernel.Get<IItemsUpdateService>().UpdateAsync();

            var items = await Bootstraper.Kernel.Get<IItemsProviderService>().GetAsync();
        }
    }
}
