using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTHelper2.Application.Champions.Classes
{
    public interface IClassesProviderService
    {
        Task<List<ViewModelClass>> GetClassesAsync();
        Task SaveClassesAsync(List<ClassDto> classes);
    }
}
