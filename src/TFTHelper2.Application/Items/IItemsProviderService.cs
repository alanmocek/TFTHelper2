using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTHelper2.Application.Items
{
    public interface IItemsProviderService
    {
        Task<List<ViewModelItem>> GetAsync();
        Task SaveAsync(List<ItemDto> items);
    }
}
