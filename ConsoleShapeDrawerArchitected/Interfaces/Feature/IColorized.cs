
namespace ConsoleShapeDrawerArchitectured.Interfaces.Feature
{
    public interface IColorized : IDrawable
    {
        string BorderColor { get; set; }
        string FillColor { get; set; }
    }
}
