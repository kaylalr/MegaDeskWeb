using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk
{
    public struct Desk
    {
        public decimal Width { get; set; }
        public decimal Depth { get; set; }
        public int Drawers { get; set;  }
        public int Material { get; set; }

        public Desk(decimal width, decimal depth, int drawers, int deskMaterial)
        {
            Width = width;
            Depth = depth;
            Drawers = drawers;
            Material = deskMaterial;
        }
    }
}
