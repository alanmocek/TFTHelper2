using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TFTHelper2.Application.Champions.Classes;
using TFTHelper2.Application.Champions.Origins;
using TFTHelper2.Application.Items;
using TFTHelper2.Client.ViewModels.PrimaryViewViewModels;

namespace TFTHelper2.Client.ViewModels
{
    public class PrimaryViewViewModel : ViewModelBase
    {
        public event Action Updated;

        private readonly ClassesViewViewModel _classesViewViewModel;
        private readonly OriginsViewViewModel _originsViewViewModel;
        private readonly ItemsViewViewModel _itemsViewViewModel;

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

        public PrimaryViewViewModel()
        {
            _originsViewViewModel = new OriginsViewViewModel();
            _classesViewViewModel = new ClassesViewViewModel();
            _itemsViewViewModel = new ItemsViewViewModel();

            CurrentViewModel = _classesViewViewModel;

            ChangeViewCommand = new RelayCommandAsync(ChangeView);
            UpdateCommand = new RelayCommandAsync(Update);

            Updated += _originsViewViewModel.OnUpdated;
            Updated += _classesViewViewModel.OnUpdated;
            Updated += _itemsViewViewModel.OnUpdated;
        }

        public ICommand ChangeViewCommand { get; set; }
        private async Task ChangeView(object x)
        {
            string view = (string)x;

            switch (view)
            {
                case "classes":
                    {
                        CurrentViewModel = _classesViewViewModel;
                        break;
                    }
                case "origins":
                    {
                        CurrentViewModel = _originsViewViewModel;
                        break;
                    }
                case "items":
                    {
                        CurrentViewModel = _itemsViewViewModel;
                        break;
                    }
                default:
                    {
                        CurrentViewModel = _itemsViewViewModel;
                        break;
                    }
            }
        }

        public ICommand UpdateCommand { get; set; }
        private async Task Update(object x)
        {
            await Bootstraper.Kernel.Get<IClassesUpdateService>().UpdateAsync();
            await Bootstraper.Kernel.Get<IOriginsUpdateService>().UpdateAsync();
            await Bootstraper.Kernel.Get<IItemsUpdateService>().UpdateAsync();

            Updated?.Invoke();
        }
    }
}
