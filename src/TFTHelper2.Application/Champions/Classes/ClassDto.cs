using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTHelper2.Application.Champions.Classes
{
    public class ClassDto
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<BonusDto> Bonuses { get; set; }
    }
}
