using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFTHelper2.Application.ApiReader;


using Ninject;
using TFTHelper2.Application.Champions;
using TFTHelper2.Application.Champions.Classes;

namespace TFTHelper2.Client.ViewModels
{
    public class MainViewModel
    {

        private readonly IClassesUpdateService _classesUpdateService;

        private readonly IClassesProviderService _classesProviderService;

        public MainViewModel()
        {
            Bootstraper.Init();

            _classesUpdateService = Bootstraper.Kernel.Get<IClassesUpdateService>();

            _classesProviderService = Bootstraper.Kernel.Get<IClassesProviderService>();

            Testuej2();
        }

        private async void Testuej2()
        {
            var list = await _classesProviderService.GetClassesAsync();
            //await _classesUpdateService.UpdateAsync();
        }
    }
}
