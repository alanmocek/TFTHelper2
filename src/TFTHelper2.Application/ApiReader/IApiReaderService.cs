using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTHelper2.Application.ApiReader
{
    public interface IApiReaderService
    {
        Task<string> ReadApiAsync(string path);
    }
}
