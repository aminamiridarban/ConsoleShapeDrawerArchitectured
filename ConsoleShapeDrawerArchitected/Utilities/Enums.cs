using System.ComponentModel;
namespace ConsoleShapeDrawerArchitectured.Utilities
{
    public class Enums
    {
        public enum ShapeTypes : byte
        {
            [DefaultValue("N"), Description("Choose this selection if you ignore to continue drawing..!")]
            None = 0,
            [DefaultValue("C"), Description("Need radius for circle.")]
            Circle = 1,
            [DefaultValue("S"), Description("Need side length for square.")]
            Square = 2,
            [DefaultValue("R"), Description("Need 2 sides lengths for rectangle.")]
            Rectangle = 3,
            [DefaultValue("T"), Description("Need 3 lengths of vertices for triangle.")]
            Triangle = 4

        }
        public enum ShadeTypes : byte
        {
            [DefaultValue(' '), Description("This is none shade")]
            None = 0,
            [DefaultValue('█'), Description("This is Full shade fill")]
            Full = 1,
            [DefaultValue('▓'), Description("This is Dark shade fill")]
            Dark = 2,
            [DefaultValue('▒'), Description("This is Medium shade fill")]
            Medium = 3,
            [DefaultValue('░'), Description("This is Light shade fill")]
            Light = 4

        }
        public enum TriangleTypes : byte
        {
            [DefaultValue("Equilateral Triangle"), Description("Has SideABLength==SideBCLength && SideBCLength==SideACLength.")]
            Equilateral = 0,
            [DefaultValue("Isosceles Triangle"), Description("Has SideABLength==SideBCLength || SideABLength==SideACLength || SideBCLength==SideACLength.")]
            Isosceles = 1,
            [DefaultValue("Scalene Triangle"), Description("Has none equal sides.")]
            Scalene = 2,
        }
        public enum AvailableColors : byte
        {
            [DefaultValue("#FF0000"), Description("This is Red Color")]
            Red = 1,
            [DefaultValue("#00FF00"), Description("This is Green Color")]
            Green = 2,
            [DefaultValue("#0000FF"), Description("This is Blue Color")]
            Blue = 3,
            [DefaultValue("#FAFA33"), Description("This is Lemon Color")]
            Lemon = 4,
            [DefaultValue("#FFFF00"), Description("This is Yellow Color")]
            Yellow = 5,
            [DefaultValue("#FFC0CB"), Description("This is Pink Color")]
            Pink = 6,
            [DefaultValue("#A020F0"), Description("This is Purple Color")]
            Purple = 7,
            [DefaultValue("#964B00"), Description("This is Brown Color")]
            Brown = 8,
            [DefaultValue("#FFFFFF"), Description("This is White Color")]
            White = 9,
            [DefaultValue("#000000"), Description("This is Black Color")]
            Black = 10,
            [DefaultValue("#777777"), Description("This is Gray Color")]
            Gray = 11
        }
        public enum OutPutTypes : byte
        {
            [DefaultValue("N"), Description("Choose this selection if you ignore to continue put your shape out..!")]
            None = 0,
            [DefaultValue("D"), Description("Draw this shape to this console screen..!")]
            Draw = 1,
            [DefaultValue("S"), Description("Store this shape to your desire path in local machine..!")]
            Store = 2,
            [DefaultValue("C"), Description("Present computation results for this shape..!")]
            Calculations = 3,
        }
    }
}
