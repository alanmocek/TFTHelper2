using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFTHelper2.Application.ApiReader;

namespace TFTHelper2.Application.Champions.Origins
{
    public class OriginsUpdateService : IOriginsUpdateService
    {
        private readonly IApiReaderService _apiReaderService;
        private IOriginsProviderService _originsProviderService;

        public OriginsUpdateService(IApiReaderService apiReaderService, IOriginsProviderService originsProviderService)
        {
            _apiReaderService = apiReaderService;
            _originsProviderService = originsProviderService;
        }

        public async Task UpdateAsync()
        {
            string originsString = await _apiReaderService.ReadApiAsync("/origins.json");

            var originsDictionary = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, OriginDto>>(originsString);

            List<OriginDto> origins = new List<OriginDto>();

            foreach (KeyValuePair<string, OriginDto> pair in originsDictionary)
            {
                if (pair.Value.Description is null)
                {
                    pair.Value.Description = string.Empty;
                }

                origins.Add(pair.Value);
            }

            await _originsProviderService.SaveAsync(origins);
        }
    }
}
