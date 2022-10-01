using Microsoft.Extensions.Logging;
using ConsoleShapeDrawerArchitectured.Utilities;

namespace ConsoleShapeDrawerArchitectured.Services.DrawServices
{
    public sealed class DrawSquareService : Abstractions.Services.DrawServiceBase<Abstractions.Shapes.SquareBase>
    {
        public static ILogger<Program>? _logger;
        public DrawSquareService()
        {
        }
        public DrawSquareService(ILogger<Program> logger, Models.Square square)
        {
            try
            {
                Draw(square);
            }
            catch (Exception ex)
            {
                string errLog = $"An Exception raised with message : {ex.Message}, stackTrace : {ex.StackTrace}";
                logger.LogError(ex, errLog);
            }
        }
        protected override void Draw(Abstractions.Shapes.SquareBase square)
        {
            base.Draw(square);

            int SideLength = square.SideLength;

            double Width = SideLength * 2.1;
            double Height = SideLength;
            square.StartPointX = (int)Utilities.ConsoleScreen.Cursor.AxisPointX;
            square.StartPointY = (int)Utilities.ConsoleScreen.Cursor.AxisPointY;
            char fill = char.Parse(Enums.ShadeTypes.Dark.DefaultValueAttribute());

            string s = "╔";
            string space = "";
            string temp = "";
            for (int i = 0; i < Width; i++)
            {
                space += fill;
                s += "═";
            }

            for (int j = 0; j < square.StartPointX; j++)
                temp += " ";

            s += "╗" + "\n";

            for (int i = 0; i < Height; i++)
                s += temp + "║" + space + "║" + "\n";

            s += temp + "╚";
            for (int i = 0; i < Width; i++)
                s += "═";

            s += "╝" + "\n";


            Console.CursorTop = square.StartPointY;
            Console.CursorLeft = square.StartPointX;
            Console.Write(s);
        }
        public string DrawString(Abstractions.Shapes.SquareBase square)
        {
            System.Text.StringBuilder retVal = new System.Text.StringBuilder();

            int SideLength = square.SideLength;

            double Width = SideLength * 2.1;
            double Height = SideLength;
            square.StartPointX = (int)Utilities.ConsoleScreen.Cursor.AxisPointX;
            square.StartPointY = (int)Utilities.ConsoleScreen.Cursor.AxisPointY;
            char fill = char.Parse(Enums.ShadeTypes.Dark.DefaultValueAttribute());

            retVal.Append("╔");
            string space = "";
            string temp = "";
            for (int i = 0; i < Width; i++)
            {
                space += fill;
                retVal.Append("═");
            }

            for (int j = 0; j < square.StartPointX; j++)
                temp += " ";

            retVal.Append("╗" + "\n");

            for (int i = 0; i < Height; i++)
                retVal.Append(temp + "║" + space + "║" + "\n");

            retVal.Append(temp + "╚");
            for (int i = 0; i < Width; i++)
                retVal.Append("═");

            retVal.Append("╝" + "\n");

            return retVal.ToString();
        }
    }
}
