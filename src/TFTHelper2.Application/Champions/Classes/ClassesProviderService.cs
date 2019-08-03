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
        /// Without .json
        /// </summary>
        private readonly string _filePath;
        private readonly IDataSaveReadService _dataSaveReadService;

        public ClassesProviderService(IDataSaveReadService dataSaveReadService, string filePath)
        {
            _dataSaveReadService = dataSaveReadService;
            _filePath = filePath;
        }

        public async Task<List<ViewModelClass>> GetClassesAsync()
        {
            var classesDto = await _dataSaveReadService.ReadFromFileAsync<ClassDto>(_filePath);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClassDto, ViewModelClass>());
            IMapper mapper = config.CreateMapper();

            var classesViewModel = mapper.Map<List<ClassDto>, List<ViewModelClass>>(classesDto);

            return classesViewModel;
        }

        public async Task SaveClassesAsync(List<ClassDto> classes)
        {
            await _dataSaveReadService.SaveToFileAsync(classes, _filePath);
        }
    }
}
