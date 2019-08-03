
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFTHelper2.Application.ApiReader;

using Ninject;
using TFTHelper2.Application.Champions.Classes;
using TFTHelper2.Application.DataSaveRead;

namespace TFTHelper2
{
    public static class Bootstraper
    {
        public static IKernel Kernel { get; } = new StandardKernel();

        private static string baseUrl = "https://solomid-resources.s3.amazonaws.com/blitz/tft/data";

        private static string classesFilePath = "classes";

        public static void Init()
        {
            Kernel.Bind<IApiReaderService>().To<ApiReaderService>().WithConstructorArgument("baseUrl", baseUrl);
            Kernel.Bind<IDataSaveReadService>().To<DataSaveReadService>();

            //Providers
            Kernel.Bind<IClassesProviderService>().To<ClassesProviderService>().WithConstructorArgument(Kernel.Get<IDataSaveReadService>()).WithConstructorArgument("filePath",classesFilePath);

            //Updaters
            Kernel.Bind<IClassesUpdateService>().To<ClassesUpdateService>().WithConstructorArgument(Kernel.Get<IApiReaderService>()).WithConstructorArgument(Kernel.Get<IClassesProviderService>());

        }
    }
}
