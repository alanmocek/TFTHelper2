using System;
using TFTHelper2.Application.ApiReader;
using Ninject;
using TFTHelper2.Application.Champions.Classes;
using TFTHelper2.Application.DataSaveRead;
using TFTHelper2.Application.Champions.Origins;
using TFTHelper2.Application.Items;

namespace TFTHelper2
{
    public static class Bootstraper
    {
        public static IKernel Kernel { get; } = new StandardKernel();

        private static string baseUrl = "https://solomid-resources.s3.amazonaws.com/blitz/tft/data";

        private static string mainPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/TFT Helper/";

        private static string classesFilePath = "classes";
        private static string originsFilePath = "origins";
        private static string itemsFilePath = "items";

        public static void Init()
        {
            Kernel.Bind<IApiReaderService>().To<ApiReaderService>().WithConstructorArgument("baseUrl", baseUrl);
            Kernel.Bind<IDataSaveReadService>().To<DataSaveReadService>().WithConstructorArgument("mainPath", mainPath);

            //Providers
            Kernel.Bind<IClassesProviderService>().To<ClassesProviderService>().WithConstructorArgument(Kernel.Get<IDataSaveReadService>()).WithConstructorArgument("filePath",classesFilePath);
            Kernel.Bind<IOriginsProviderService>().To<OriginsProviderService>().WithConstructorArgument(Kernel.Get<IDataSaveReadService>()).WithConstructorArgument("filePath", originsFilePath);
            Kernel.Bind<IItemsProviderService>().To<ItemsProviderService>().WithConstructorArgument(Kernel.Get<IDataSaveReadService>()).WithConstructorArgument("filePath", itemsFilePath);

            //Updaters
            Kernel.Bind<IClassesUpdateService>().To<ClassesUpdateService>().WithConstructorArgument(Kernel.Get<IApiReaderService>()).WithConstructorArgument(Kernel.Get<IClassesProviderService>());
            Kernel.Bind<IOriginsUpdateService>().To<OriginsUpdateService>().WithConstructorArgument(Kernel.Get<IApiReaderService>()).WithConstructorArgument(Kernel.Get<IOriginsProviderService>());
            Kernel.Bind<IItemsUpdateService>().To<ItemsUpdateService>().WithConstructorArgument(Kernel.Get<IApiReaderService>()).WithConstructorArgument(Kernel.Get<IItemsProviderService>());
        }
    }
}
