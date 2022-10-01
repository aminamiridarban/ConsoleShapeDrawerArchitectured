using ConsoleShapeDrawerArchitectured.Utilities;
using Microsoft.Extensions.Logging;

namespace ConsoleShapeDrawerArchitectured.Services.DrawServices
{
    public sealed class DrawCircleService : Abstractions.Services.DrawServiceBase<Abstractions.Shapes.CircleBase>
    {
        public static ILogger<Program>? _logger;
        public DrawCircleService()
        {
        }
        public DrawCircleService(ILogger<Program> logger, Models.Circle circle)
        {
            try
            {
                Draw(circle);
            }
            catch (Exception ex)
            {
                string errLog = $"An Exception raised with message : {ex.Message}, stackTrace : {ex.StackTrace}";
                logger.LogError(ex, errLog);
            }
        }
        protected override void Draw(Abstractions.Shapes.CircleBase circle)
        {
            base.Draw(circle);

            char fill = char.Parse(Enums.ShadeTypes.Dark.DefaultValueAttribute());
            int radius = circle.Radius;
            circle.StartPointX = (int)ConsoleScreen.Cursor.AxisPointX;
            circle.StartPointY = (int)ConsoleScreen.Cursor.AxisPointY;
            const double thickness = 0.2;
            char symbol = '⋅';


            while (radius <= 0) ;

            Console.WriteLine();
            double rIn = radius - thickness, rOut = radius + thickness;

            for (double y = radius; y >= -radius; --y)
            {
                for (double x = -radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {//border
                        Console.Write(symbol);
                    }
                    else if (value <= rOut * rOut)
                    {//fill
                        Console.Write(fill);
                    }
                    else
                    {//whitespace
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
        }
        public string DrawString(Abstractions.Shapes.CircleBase circle)
        {
            System.Text.StringBuilder retVal = new System.Text.StringBuilder();

            char fill = char.Parse(Enums.ShadeTypes.Dark.DefaultValueAttribute());
            int radius = circle.Radius;
            circle.StartPointX = (int)ConsoleScreen.Cursor.AxisPointX;
            circle.StartPointY = (int)ConsoleScreen.Cursor.AxisPointY;
            const double thickness = 0.2;


            char symbol = '⋅';


            while (radius <= 0) ;
            retVal.Append(Environment.NewLine);

            double rIn = radius - thickness, rOut = radius + thickness;

            for (double y = radius; y >= -radius; --y)
            {
                for (double x = -radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {//border
                        retVal.Append(symbol);
                    }
                    else if (value <= rOut * rOut)
                    {//fill
                        retVal.Append(fill);
                    }
                    else
                    {//whitespace
                        retVal.Append(" ");
                    }

                }
                retVal.Append(Environment.NewLine);
            }

            return retVal.ToString();
        }
    }
}
