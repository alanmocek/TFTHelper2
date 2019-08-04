using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTHelper2.Application.Champions.Origins
{
    public interface IOriginsProviderService
    {
        Task<List<ViewModelOrigin>> GetAsync();
        Task SaveAsync(List<OriginDto> origins);
    }
}
