using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TFTHelper2.Application.Items;

namespace TFTHelper2.Client.ViewModels.PrimaryViewViewModels
{
    public class ItemsViewViewModel : ViewModelBase
    {

        private readonly IItemsProviderService _itemsProviderService;

        private List<ViewModelItem> allItems = new List<ViewModelItem>();

        public List<ViewModelItem> BasicItems => allItems.Where(i => i.Depth == 1).ToList();

        public List<ViewModelItem> SelectedItems => BasicItems.Where(i => i.IsHiden == false).ToList();

        public ItemsViewViewModel()
        {
            _itemsProviderService = Bootstraper.Kernel.Get<IItemsProviderService>();

            ChangeItemVisibilityCommand = new RelayCommandAsync(ChangeItemVisibility);

            _ = GetItemsAsync();
        }

        private async Task GetItemsAsync()
        {
            allItems = await _itemsProviderService.GetAsync();
            UpdateProperty(nameof(BasicItems));
            UpdateProperty(nameof(SelectedItems));
        }

        public ICommand ChangeItemVisibilityCommand { get; set; }
        public async Task ChangeItemVisibility(object x)
        {
            ViewModelItem item = (ViewModelItem)x;

            item.IsHiden = !item.IsHiden;

            UpdateProperty(nameof(BasicItems));
            UpdateProperty(nameof(SelectedItems));
        }

        public void OnUpdated()
        {
            _ = GetItemsAsync();
        }
    }
}
