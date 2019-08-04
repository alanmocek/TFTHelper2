using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFTHelper2.Application.DataSaveRead;

namespace TFTHelper2.Application.Items
{
    public class ItemsProviderService : IItemsProviderService
    {
        /// <summary>
        /// without file format
        /// </summary>
        private readonly string _filePath;
        private readonly IDataSaveReadService _dataSaveReadService;

        public ItemsProviderService(IDataSaveReadService dataSaveReadService, string filePath)
        {
            _dataSaveReadService = dataSaveReadService;
            _filePath = filePath;
        }

        public async Task<List<ViewModelItem>> GetAsync()
        {
            var itemsDto = await _dataSaveReadService.ReadFromFileAsync<ItemDto>(_filePath);

            var configItems = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ItemDto, ViewModelItem>();
            });
            IMapper mapper = configItems.CreateMapper();


            var itemsViewModels = mapper.Map<List<ItemDto>, List<ViewModelItem>>(itemsDto);

            foreach(ViewModelItem item in itemsViewModels)
            {
                item.CreateRecipes(itemsViewModels);
            }

            return itemsViewModels;
        }

        public async Task SaveAsync(List<ItemDto> items)
        {
            await _dataSaveReadService.SaveToFileAsync(items, _filePath);
        }
    }
}
