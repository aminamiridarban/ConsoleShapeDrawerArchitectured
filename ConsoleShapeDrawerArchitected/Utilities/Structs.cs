
namespace ConsoleShapeDrawerArchitectured.Utilities
{
    public class Structs
    {
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct WindowRectangle : IEquatable<WindowRectangle>
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public readonly int Width => Right - Left;
            public readonly int Height => Bottom - Top;
            public readonly bool Equals(WindowRectangle other)
            {
                return (Left == other.Left && Right == other.Right && Top == other.Right && Bottom == other.Bottom);
            }
        }
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct WindowResolution : IEquatable<WindowResolution>
        {
            public int Width;
            public int Height;

            public readonly bool Equals(WindowResolution other)
            {
                return (Width == other.Width && Height == other.Height);
            }
        }
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct Coordinate : IEquatable<Coordinate>
        {
            public double AxisPointX;
            public double AxisPointY;

            public readonly bool Equals(Coordinate other)
            {
                return (AxisPointX == other.AxisPointX && AxisPointY == other.AxisPointY);
            }
        }

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct Range : IEquatable<Range>
        {
            public byte? MinValue;
            public byte? MaxValue;
            public readonly bool Equals(Range other)
            {
                return (MinValue == other.MinValue && MaxValue == other.MaxValue);
            }
        }
    }
}
