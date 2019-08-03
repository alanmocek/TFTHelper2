using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFTHelper2.Client.ViewModels;

namespace TFTHelper2.Client
{
    public class ViewModelLocalicator
    {
        private MainViewModel main;
        public MainViewModel Main => main;

        public ViewModelLocalicator()
        {
            main = new MainViewModel();
        }
    }
}
