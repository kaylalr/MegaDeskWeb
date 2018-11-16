using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk
{
    public struct Desk
    {
        public enum SurfaceMaterial
        {
            Laminate,
            Oak,
            Rosewood,
            Veneer,
            Pine
        }

        public decimal Width { get; set; }
        public decimal Depth { get; set; }
        public int Drawers { get; set;  }
        public string Material { get; set; }

        public Desk(decimal width, decimal depth, int drawers, string deskMaterial)
        {
            Width = width;
            Depth = depth;
            Drawers = drawers;
            Material = deskMaterial;
        }
    }
}
