using ConsoleShapeDrawerArchitectured.Utilities;
using Microsoft.Extensions.Logging;

namespace ConsoleShapeDrawerArchitectured.Services.DrawServices
{
    public sealed class DrawRectangleService : Abstractions.Services.DrawServiceBase<Abstractions.Shapes.RectangleBase>
    {
        public static ILogger<Program>? _logger;
        public DrawRectangleService()
        {
        }
        public DrawRectangleService(ILogger<Program> logger, Models.Rectangle rectangle)
        {
            try
            {
                Draw(rectangle);
            }
            catch (Exception ex)
            {
                string errLog = $"An Exception raised with message : {ex.Message}, stackTrace : {ex.StackTrace}";
                logger.LogError(ex, errLog);
            }
        }
        protected override void Draw(Abstractions.Shapes.RectangleBase rectangle)
        {
            base.Draw(rectangle);

            double Width = rectangle.Width * 2.1;
            double Height = rectangle.Length;
            rectangle.StartPointX = (int)Utilities.ConsoleScreen.Cursor.AxisPointX;
            rectangle.StartPointY = (int)Utilities.ConsoleScreen.Cursor.AxisPointY;



            char fill = char.Parse(Enums.ShadeTypes.Dark.DefaultValueAttribute());
            string s = "╔";
            string space = "";
            string temp = "";
            for (int i = 0; i < Width; i++)
            {
                space += fill;
                s += "═";
            }

            for (int j = 0; j < rectangle.StartPointX; j++)
                temp += " ";

            s += "╗" + "\n";

            for (int i = 0; i < Height; i++)
                s += temp + "║" + space + "║" + "\n";

            s += temp + "╚";
            for (int i = 0; i < Width; i++)
                s += "═";

            s += "╝" + "\n";


            Console.CursorTop = rectangle.StartPointY;
            Console.CursorLeft = rectangle.StartPointX;
            Console.Write(s);
        }
        public string DrawString(Abstractions.Shapes.RectangleBase rectangle)
        {
            System.Text.StringBuilder retVal = new System.Text.StringBuilder();

            double Width = rectangle.Width * 2.1;
            double Height = rectangle.Length;
            rectangle.StartPointX = (int)Utilities.ConsoleScreen.Cursor.AxisPointX;
            rectangle.StartPointY = (int)Utilities.ConsoleScreen.Cursor.AxisPointY;



            char fill = char.Parse(Enums.ShadeTypes.Dark.DefaultValueAttribute());
            retVal.Append("╔");
            string space = "";
            string temp = "";
            for (int i = 0; i < Width; i++)
            {
                space += fill;
                retVal.Append("═");
            }

            for (int j = 0; j < rectangle.StartPointX; j++)
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
