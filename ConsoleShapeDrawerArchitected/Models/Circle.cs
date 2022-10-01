
namespace ConsoleShapeDrawerArchitectured.Models
{
    public sealed class Circle :
        Abstractions.Shapes.CircleBase
    {
        public Circle()
        {

        }
        public Circle(string title)
            : base(title)
        {
        }
        public Circle(byte radius)
            : base(radius)
        {

        }
        public Circle(byte radius, int startPointX, int startPointY)
            : base(radius, startPointX, startPointY)
        {
        }
        public Circle(byte radius, string borderColor, string fillColor)
            : base(radius, borderColor, fillColor)
        {
        }
        public Circle(string title, int startPointX, int startPointY, byte radius)
          : base(title, startPointX, startPointY, radius)
        {
        }
        public Circle(byte radius, int startPointX, int startPointY, string borderColor, string fillColor)
            : base(radius, startPointX, startPointY, borderColor, fillColor)
        {

        }

        [System.ComponentModel.DataAnnotations.Display(Name = "Radius", ResourceType = typeof(Resources.MessageResource))]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Range(3, 30)]
        public override byte Radius { get => base.Radius; set => base.Radius = value; }
    }
}
