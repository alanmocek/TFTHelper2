using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFTHelper2.Application.DataSaveRead;

using AutoMapper;

namespace TFTHelper2.Application.Champions.Classes
{
    public class ClassesProviderService : IClassesProviderService
    {
        /// <summary>
        /// Without file format
        /// </summary>
        private readonly string _filePath;
        private readonly IDataSaveReadService _dataSaveReadService;

        public ClassesProviderService(IDataSaveReadService dataSaveReadService, string filePath)
        {
            _dataSaveReadService = dataSaveReadService;
            _filePath = filePath;
        }

        public async Task<List<ViewModelClass>> GetAsync()
        {
            var classesDto = await _dataSaveReadService.ReadFromFileAsync<ClassDto>(_filePath);

            var configClasses = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<ClassDto, ViewModelClass>();
                cfg.CreateMap<BonusDto, ViewModelBonus>();
                });
            IMapper mapperClasses = configClasses.CreateMapper();


            var classViewModels = mapperClasses.Map<List<ClassDto>, List<ViewModelClass>>(classesDto);

            return classViewModels;
        }

        public async Task SaveAsync(List<ClassDto> classes)
        {
            await _dataSaveReadService.SaveToFileAsync(classes, _filePath);
        }
    }
}
