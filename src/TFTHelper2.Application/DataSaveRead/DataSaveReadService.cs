using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TFTHelper2.Application.DataSaveRead
{
    public class DataSaveReadService : IDataSaveReadService
    {
        private readonly string _mainPath;

        public DataSaveReadService(string mainPath)
        {
            _mainPath = mainPath;

            System.IO.Directory.CreateDirectory(_mainPath);
        }

        public async Task<List<T>> ReadFromFileAsync<T>(string path)
        {
            path = $"{_mainPath}\\{path}";

            List<T> items = new List<T>();

            using (var reader = new StreamReader($"{path}.json"))
            {
                string json = await reader.ReadToEndAsync();

                items = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(json);
            }

            return items;
        }

        public async Task SaveToFileAsync<T>(List<T> items, string path)
        {
            path = $"{_mainPath}\\{path}";

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(items);

            using (var writer = new StreamWriter($"{path}.json"))
            {
                await writer.WriteAsync(json);
            }
        }
    }
}
