
namespace ConsoleShapeDrawerArchitectured.Interfaces.Shape
{
    public interface IShapeCircle :
        Feature.ICalculatableShapeScales
    {
        byte Radius { get; set; }
    }
}
