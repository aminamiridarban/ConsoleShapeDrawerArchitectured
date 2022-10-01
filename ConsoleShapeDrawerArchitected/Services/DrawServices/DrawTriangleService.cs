using Microsoft.Extensions.Logging;
using ConsoleShapeDrawerArchitectured.Utilities;

namespace ConsoleShapeDrawerArchitectured.Services.DrawServices
{
    public sealed class DrawTriangleService : Abstractions.Services.DrawServiceBase<Abstractions.Shapes.TriangleBase>
    {
        public static ILogger<Program>? _logger;
        public DrawTriangleService()
        {
        }
        public DrawTriangleService(ILogger<Program> logger, Models.Triangle triangle)
        {
            try
            {
                Draw(triangle);
            }
            catch (Exception ex)
            {
                string errLog = $"An Exception raised with message : {ex.Message}, stackTrace : {ex.StackTrace}";
                logger.LogError(ex, errLog);
            }
        }
        protected override void Draw(Abstractions.Shapes.TriangleBase triangle)
        {
            IOServices.IOScreenService io = new IOServices.IOScreenService(_logger);
            if (triangle.IsDrawable())
                base.Draw(triangle);
            else
                io.WriteInColor($"{Resources.MessageResource.UnAcceptableVertices} ", ConsoleColor.Yellow, ConsoleColor.DarkRed);


            triangle.StartPointX = Console.CursorLeft;
            triangle.StartPointY = Console.CursorTop;

            // Starting coordinates

            KeyValuePair<Char, Structs.Coordinate>[] coords = triangle.RetrivingVertexCoordinates();
            double baseline = triangle.CalculateTriangleBaseLine();
            if (triangle.SidesValidityRecognition())
                for (double row = coords.GetValueByKey('A').AxisPointX; row <= baseline + 1; row++)
                {
                    for (double col = coords.GetValueByKey('A').AxisPointX; col <= baseline + 1; col++)
                    {
                        if (!triangle.IsPointInsideTriangle(
                            coords.GetValueByKey('A').AxisPointX, coords.GetValueByKey('A').AxisPointY,
                            coords.GetValueByKey('B').AxisPointX, coords.GetValueByKey('B').AxisPointY,
                            coords.GetValueByKey('C').AxisPointX, coords.GetValueByKey('C').AxisPointY, row + triangle.StartPointX, col + triangle.StartPointY)
                            )
                        {
                            io.Write(' ');
                            continue;
                        }
                        else
                            io.Write('*');

                    }
                    io.NextLine(1);
                }

            //Set cursor after drawed third point of the triangle for next actions
            io.NextLine(1);
        }
        public string DrawString(Abstractions.Shapes.TriangleBase triangle)
        {
            System.Text.StringBuilder retVal = new System.Text.StringBuilder();

            triangle.StartPointX = Console.CursorLeft;
            triangle.StartPointY = Console.CursorTop;

            // Starting coordinates
            KeyValuePair<Char, Structs.Coordinate>[] coords = triangle.RetrivingVertexCoordinates();
            double baseline = triangle.CalculateTriangleBaseLine();
            if (triangle.SidesValidityRecognition())
                for (double row = coords.GetValueByKey('A').AxisPointX; row <= baseline + 1; row++)
                {
                    for (double col = coords.GetValueByKey('A').AxisPointX; col <= baseline + 1; col++)
                    {
                        if (!triangle.IsPointInsideTriangle(
                            coords.GetValueByKey('A').AxisPointX, coords.GetValueByKey('A').AxisPointY,
                            coords.GetValueByKey('B').AxisPointX, coords.GetValueByKey('B').AxisPointY,
                            coords.GetValueByKey('C').AxisPointX, coords.GetValueByKey('C').AxisPointY, row + triangle.StartPointX, col + triangle.StartPointY)
                            )
                        {
                            retVal.Append(' ');
                            continue;
                        }
                        else
                            retVal.Append('*');

                    }
                    retVal.Append(Environment.NewLine);
                }

            return retVal.ToString();
        }
    }
}
