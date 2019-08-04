using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTHelper2.Application.Champions
{
    public class ViewModelBonus
    {
        public int Needed { get; set; }
        public string Effect { get; set; }

        public string BonusText => $"({Needed}) {Effect}";
    }
}
