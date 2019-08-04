using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFTHelper2.Application.DataSaveRead;

namespace TFTHelper2.Application.Champions.Origins
{
    public class OriginsProviderService : IOriginsProviderService
    {
        /// <summary>
        /// Without file format
        /// </summary>
        private readonly IDataSaveReadService _dataSaveReadService;
        private readonly string _filePath;

        public OriginsProviderService(IDataSaveReadService dataSaveReadService, string filePath)
        {
            _dataSaveReadService = dataSaveReadService;
            _filePath = filePath;
        }

        public async Task<List<ViewModelOrigin>> GetAsync()
        {
            var originsDto = await _dataSaveReadService.ReadFromFileAsync<OriginDto>(_filePath);

            var configClasses = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OriginDto, ViewModelOrigin>();
                cfg.CreateMap<BonusDto, ViewModelBonus>();
            });
            IMapper mapperClasses = configClasses.CreateMapper();


            var originViewModels = mapperClasses.Map<List<OriginDto>, List<ViewModelOrigin>>(originsDto);

            return originViewModels;
        }

        public async Task SaveAsync(List<OriginDto> origins)
        {
            await _dataSaveReadService.SaveToFileAsync(origins, _filePath);
        }
    }
}
