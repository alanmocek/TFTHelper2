using Ninject;
using System.Collections.Generic;
using System.Threading.Tasks;
using TFTHelper2.Application.Champions.Origins;

namespace TFTHelper2.Client.ViewModels.PrimaryViewViewModels
{
    public class OriginsViewViewModel : ViewModelBase
    {
        private readonly IOriginsProviderService _originsProviderService;

        public List<ViewModelOrigin> Origins { get; set; }

        public OriginsViewViewModel()
        {
            _originsProviderService = Bootstraper.Kernel.Get<IOriginsProviderService>();

            _ = GetOriginsAsync();
        }

        private async Task GetOriginsAsync()
        {
            Origins = await _originsProviderService.GetAsync();
            UpdateProperty(nameof(Origins));
        }

        public void OnUpdated()
        {
            _ = GetOriginsAsync();
        }
    }
}
