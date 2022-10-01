using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShapeDrawerArchitectured.Models
{
    public sealed class Triangle :
        Abstractions.Shapes.TriangleBase

    {
        [System.ComponentModel.DataAnnotations.Range(3, 30)]
        [System.ComponentModel.DataAnnotations.Display(Name = "SideABLength", ResourceType = typeof(Resources.MessageResource))]
        [System.ComponentModel.DataAnnotations.Required]
        public override byte SideABLength { get => base.SideABLength; set => base.SideABLength = value; }

        [System.ComponentModel.DataAnnotations.Range(3, 30)]
        [System.ComponentModel.DataAnnotations.Display(Name = "SideBCLength", ResourceType = typeof(Resources.MessageResource))]
        [System.ComponentModel.DataAnnotations.Required]
        public override byte SideBCLength { get => base.SideBCLength; set => base.SideBCLength = value; }

        [System.ComponentModel.DataAnnotations.Range(3, 30)]
        [System.ComponentModel.DataAnnotations.Display(Name = "SideACLength", ResourceType = typeof(Resources.MessageResource))]
        [System.ComponentModel.DataAnnotations.Required]
        public override byte SideACLength { get => base.SideACLength; set => base.SideACLength = value; }

        public Triangle()
        {

        }
        public Triangle(byte sideABLength, byte sideBCLength, byte sideACLength)
            : base(sideABLength, sideBCLength, sideACLength)
        {

        }
        public Triangle(string title)
            : base(title)
        {
        }
        public Triangle(string title, byte sideABLength, byte sideBCLength, byte sideACLength)
            : base(title, sideABLength, sideBCLength, sideACLength)
        {
        }
        public Triangle(string title, byte sideABLength, byte sideBCLength, byte sideACLength, int startPointX, int startPointY)
            : base(title, sideABLength, sideBCLength, sideACLength, startPointX, startPointY)
        {
        }
        public Triangle(int startPointX, int startPointY, byte sideABLength, byte sideBCLength, byte sideACLength)
            : base(startPointX, startPointY, sideABLength, sideBCLength, sideACLength)
        {
        }
        public Triangle(byte sideABLength, byte sideBCLength, byte sideACLength, string borderColor, string fillColor)
            : base(sideABLength, sideBCLength, sideACLength, borderColor, fillColor)
        {
        }
    }
}
