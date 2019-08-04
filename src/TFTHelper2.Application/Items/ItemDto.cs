using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTHelper2.Application.Items
{
    public class ItemDto
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Bonus { get; set; }
        public int Depth { get; set; }
        public List<string> BuildsFrom { get; set; } = new List<string>();
    }
}
