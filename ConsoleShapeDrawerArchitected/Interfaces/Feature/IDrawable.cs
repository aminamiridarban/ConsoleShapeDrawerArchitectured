
namespace ConsoleShapeDrawerArchitectured.Interfaces.Feature
{
    public interface IDrawable : Shape.IShape
    {
        int StartPointX { get; set; }
        int StartPointY { get; set; }
        abstract bool IsDrawable();
    }
}
