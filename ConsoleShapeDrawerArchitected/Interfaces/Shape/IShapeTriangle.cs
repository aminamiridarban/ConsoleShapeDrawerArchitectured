
namespace ConsoleShapeDrawerArchitectured.Interfaces.Shape
{
    public interface IShapeTriangle :
         Feature.ICalculatableTriangle
    {
        byte SideABLength { get; set; }
        byte SideBCLength { get; set; }
        byte SideACLength { get; set; }

        abstract string TriangleTypeRecognition();
        abstract bool SidesValidityRecognition();
    }
}
