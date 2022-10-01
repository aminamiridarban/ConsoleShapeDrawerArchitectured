
namespace ConsoleShapeDrawerArchitectured.Interfaces.Feature
{
    public interface ICalculatableTriangle : ICalculatableShapeScales
    {
        abstract double CalculateTriangleBaseLine();
        abstract double CalculateTriangleHeight();
        abstract double GammaCalculation();
        abstract Utilities.Structs.Coordinate CalculateThirdPointCoordinate();
        abstract KeyValuePair<Char, Utilities.Structs.Coordinate>[] RetrivingVertexCoordinates();
        abstract double AreaCalculationBaseOnPoint(double x1, double y1, double x2, double y2, double x3, double y3);
        abstract bool IsPointInsideTriangle(double x1, double y1, double x2, double y2, double x3, double y3, double x, double y);
        abstract void DrawAxisPoints(KeyValuePair<Char, Utilities.Structs.Coordinate>[] coords);
    }
}
