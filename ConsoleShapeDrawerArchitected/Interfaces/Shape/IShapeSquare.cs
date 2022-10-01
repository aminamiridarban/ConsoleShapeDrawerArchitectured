
namespace ConsoleShapeDrawerArchitectured.Interfaces.Shape
{
    public interface IShapeSquare :
         Feature.ICalculatableShapeScales
    {
        byte SideLength { get; set; }
    }
}
