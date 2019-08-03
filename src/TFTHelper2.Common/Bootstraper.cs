using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFTHelper2.Application.ApiReader;

using Ninject;

namespace TFTHelper2.Client
{
    public class Bootstraper
    {
        public static IKernel Kernel { get; } = new StandardKernel();

        private string baseUrl = "https://solomid-resources.s3.amazonaws.com/blitz/tft/data";

        public Bootstraper()
        {
            Kernel.Bind<IApiReaderService>().To<ApiReaderService>().WithConstructorArgument("baseUrl", baseUrl);
        }
    }
}
