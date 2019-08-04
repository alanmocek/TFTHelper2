using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFTHelper2.Application.ApiReader;

using Ninject;
using TFTHelper2.Application.DataSaveRead;

namespace TFTHelper2.Application.Champions.Classes
{
    public class ClassesUpdateService : IClassesUpdateService
    {
        private readonly IApiReaderService _apiReaderService;
        private readonly IClassesProviderService _classesProviderService;

        public ClassesUpdateService(IApiReaderService apiReaderService, IClassesProviderService classesProviderService)
        {
            _apiReaderService = apiReaderService;
            _classesProviderService = classesProviderService;
        }

        public async Task UpdateAsync()
        {
            string classesString = await _apiReaderService.ReadApiAsync("/classes.json");

            var classesDictionary = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, ClassDto>>(classesString);

            List<ClassDto> classes = new List<ClassDto>();

            foreach(KeyValuePair<string, ClassDto> pair in classesDictionary)
            {
                if(pair.Value.Description is null)
                {
                    pair.Value.Description = string.Empty;
                }

                classes.Add(pair.Value);
            }

            await _classesProviderService.SaveAsync(classes);
        }
    }
}
