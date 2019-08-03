using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TFTHelper2.Application.ApiReader
{
    public class ApiReaderService : IApiReaderService
    {
        private readonly string _baseUrl;

        public ApiReaderService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<string> ReadApiAsync(string path)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"{_baseUrl}{path}");
                var responseContent = await response.Content.ReadAsStringAsync();

                return responseContent;
            }
        }
    }
}
