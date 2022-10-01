
namespace ConsoleShapeDrawerArchitectured.Models
{
    public sealed class Rectangle :
        Abstractions.Shapes.RectangleBase


    {
        public Rectangle()
        {
        }
        public Rectangle(string title)
           : base(title)
        {
        }
        public Rectangle(byte length, byte width)
            : base(length, width)
        {
        }
        public Rectangle(int startPointX, int startPointY, byte length, byte width)
            : base(startPointX, startPointY, length, width)
        {
        }
        public Rectangle(byte length, byte width, string borderColor, string fillColor)
            : base(length, width, borderColor, fillColor)
        {
        }
        public Rectangle(string title, int startPointX, int startPointY, byte length, byte width)
          : base(title, startPointX, startPointY, length, width)
        {
        }
        public Rectangle(string title, int startPointX, int startPointY, byte length, byte width, string borderColor, string fillColor)
            : base(title, startPointX, startPointY, length, width, borderColor, fillColor)
        {
        }

        [System.ComponentModel.DataAnnotations.Display(Name = "RecLength", ResourceType = typeof(Resources.MessageResource))]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Range(3, 30)]
        public override byte Length { get => base.Length; set => base.Length = value; }

        [System.ComponentModel.DataAnnotations.Display(Name = "RecWidth", ResourceType = typeof(Resources.MessageResource))]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Range(3, 30)]
        public override byte Width { get => base.Width; set => base.Width = value; }
    }
}
