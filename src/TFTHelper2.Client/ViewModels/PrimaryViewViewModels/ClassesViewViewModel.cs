using Ninject;
using System.Collections.Generic;
using System.Threading.Tasks;
using TFTHelper2.Application.Champions.Classes;

namespace TFTHelper2.Client.ViewModels.PrimaryViewViewModels
{
    public class ClassesViewViewModel : ViewModelBase
    {
        private readonly IClassesProviderService _classesProviderService;

        public List<ViewModelClass> Classes { get; set; }

        public ClassesViewViewModel()
        {
            _classesProviderService = Bootstraper.Kernel.Get<IClassesProviderService>();
            _ = GetClassesAsync();
        }

        private async Task GetClassesAsync()
        {
            Classes = await _classesProviderService.GetAsync();

            UpdateProperty(nameof(Classes));
        }

        public void OnUpdated()
        {
            _ = GetClassesAsync();
        }
    }
}
