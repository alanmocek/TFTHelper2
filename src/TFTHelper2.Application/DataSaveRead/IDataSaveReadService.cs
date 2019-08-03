using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTHelper2.Application.DataSaveRead
{
    public interface IDataSaveReadService
    {
        Task SaveToFileAsync<T>(List<T> items, string path);
        Task<List<T>> ReadFromFileAsync<T>(string path);
    }
}
