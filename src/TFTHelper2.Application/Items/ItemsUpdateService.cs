using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TFTHelper2.Application.ApiReader;

namespace TFTHelper2.Application.Items
{
    public class ItemsUpdateService : IItemsUpdateService
    {
        private readonly IApiReaderService _apiReaderService;
        private readonly IItemsProviderService _itemsProviderService;

        public ItemsUpdateService(IApiReaderService apiReaderService, IItemsProviderService itemsProviderService)
        {
            _apiReaderService = apiReaderService;
            _itemsProviderService = itemsProviderService;
        }

        public async Task UpdateAsync()
        {
            var itemsString = await _apiReaderService.ReadApiAsync("/items.json");

            var itemsDictionary = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, ItemDto>>(itemsString);

            List<ItemDto> items = new List<ItemDto>();

            foreach(KeyValuePair<string, ItemDto> pair in itemsDictionary)
            {
                pair.Value.Bonus = Regex.Replace(pair.Value.Bonus, "<.*?>", String.Empty);


                items.Add(pair.Value);
            }

            await _itemsProviderService.SaveAsync(items);
        }
    }
}
