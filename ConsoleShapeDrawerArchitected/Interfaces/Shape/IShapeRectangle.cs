
namespace ConsoleShapeDrawerArchitectured.Interfaces.Shape
{
    public interface IShapeRectangle :
          Feature.ICalculatableShapeScales
    {
        byte Length { get; set; }
        byte Width { get; set; }
    }
}
