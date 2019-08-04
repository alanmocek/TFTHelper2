﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTHelper2.Application.Champions.Origins
{
    public class ViewModelOrigin
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ViewModelBonus> Bonuses { get; set; }
    }
}
