
namespace ConsoleShapeDrawerArchitectured.Models
{
    public sealed class Square :
        Abstractions.Shapes.SquareBase
    {
        public Square()
        {
        }
        public Square(byte sideLength)
            : base(sideLength)
        {
        }
        public Square(string title)
            : base(title)
        {
        }
        public Square(string title, byte sideLength)
            : base(title, sideLength)
        {
        }
        public Square(int startPointX, int startPointY, byte sideLength)
            : base(startPointX, startPointY, sideLength)
        {
        }
        public Square(byte sideLength, string borderColor, string fillColor)
            : base(sideLength, borderColor, fillColor)
        {
        }
        public Square(string title, int startPointX, int startPointY, byte sideLength)
            : base(title, startPointX, startPointY, sideLength)
        {
        }
        public Square(string title, byte sideLength, string borderColor, string fillColor)
            : base(title, sideLength, borderColor, fillColor)
        {
        }
        public Square(int startPointX, int startPointY, byte sideLength, string borderColor, string fillColor)
            : base(startPointX, startPointY, sideLength, borderColor, fillColor)
        {
        }
        public Square(string title, int startPointX, int startPointY, byte sideLength, string borderColor, string fillColor)
            : base(title, startPointX, startPointY, sideLength, borderColor, fillColor)
        {
        }

        [System.ComponentModel.DataAnnotations.Display(Name = "SideLength", ResourceType = typeof(Resources.MessageResource))]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Range(3, 30)]
        public override byte SideLength { get => base.SideLength; set => base.SideLength = value; }
    }
}
