
namespace ConsoleShapeDrawerArchitectured.Utilities
{
    /// <summary>
    /// Provides Console appearance functionality.
    /// </summary>
    public static class ConsoleScreen
    {
        #region Properties

        private static System.Text.Encoding _encoding = System.Text.Encoding.UTF8;
        private static bool _cursorVisibility;
        private static string? _title;
        private static ConsoleColor _backgroundColor;
        private static ConsoleColor _foregroundColor;
        private static readonly Structs.WindowResolution _screenResolution = GetScreenResolution();
        private static readonly Structs.WindowResolution _consoleResolution = GetConsoleResolution();
        private static Structs.Coordinate _cursor;


        public static Structs.Coordinate Cursor
        {
            get
            {
                return GetCursor();
            }
            set
            {
                _cursor = value;
                SetCursor(_cursor);
            }
        }
        /// <summary>
        /// Get Console Screen Resolution
        /// </summary>
        public static Structs.WindowResolution ConsoleResolution
        {
            get => _consoleResolution;
        }

        /// <summary>
        /// Get Desktop Screen Resolution 
        /// </summary>
        public static Structs.WindowResolution ScreenResolution
        {
            get => _screenResolution;
        }
        /// <summary>
        /// Console OutPut Encoding 
        /// </summary>
        public static System.Text.Encoding Encoding
        {
            get => _encoding;
            set
            {
                _encoding = value;
                ConsoleEncoding(_encoding);
            }
        }
        /// <summary>
        /// Console Cursor Visibility 
        /// </summary>
        public static bool CursorVisibility
        {
            get => _cursorVisibility;
            set
            {
                _cursorVisibility = value;
                ConsoleCursorVisibility(_cursorVisibility);
            }
        }
        /// <summary>
        /// Console Background Color
        /// </summary>
        public static ConsoleColor BackgroundColor
        {
            get => _backgroundColor;
            set
            {
                _backgroundColor = value;
                ConsoleBackground(_backgroundColor);
            }
        }
        /// <summary>
        /// Console Forground Color
        /// </summary>
        public static ConsoleColor ForegroundColor
        {
            get => _foregroundColor;
            set
            {
                _foregroundColor = value;
                ConsoleForeGround(_foregroundColor);
            }
        }
        /// <summary>
        /// Set Console Window Title
        /// </summary>
        public static string ScreenTitle
        {
            get => _title;
            set
            {
                _title = value;
                ConsoleTitle(_title);
            }
        }

        #endregion Properties

        #region Public Methods

        private static void ConsoleEncoding(System.Text.Encoding encoding)
        {
            Console.OutputEncoding = encoding;
        }
        /// <summary>
        /// Set Cursor Visibility
        /// </summary>
        /// <param name="visibility"></param>
        private static void ConsoleCursorVisibility(bool visibility)
        {
            Console.CursorVisible = visibility;
        }
        /// <summary>
        /// Changes the console window Background color
        /// </summary>
        /// <param name="color"></param>
        private static void ConsoleBackground(ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }
        /// <summary>
        /// Changes the console window forground color
        /// </summary>
        /// <param name="color"></param>
        private static void ConsoleForeGround(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
        /// <summary>
        /// Gets the Desktop Screen Resolution
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private static Structs.WindowResolution GetScreenResolution()
        {
            return new Structs.WindowResolution { Height = Console.LargestWindowHeight, Width = Console.LargestWindowWidth };
        }
        /// <summary>
        /// Gets the Console Screen Resolution
        /// </summary>
        /// <returns></returns>
        private static Structs.WindowResolution GetConsoleResolution()
        {
            return new Structs.WindowResolution { Height = Console.WindowHeight, Width = Console.WindowWidth };
        }


        /// <summary>
        /// Set up cursor in special location inside console window base on Coordinates
        /// </summary>
        /// <param name="coords"></param>
        public static void SetCursor(Structs.Coordinate coords)
        {
            Console.SetCursorPosition((int)coords.AxisPointX, (int)coords.AxisPointY);
        }
        /// <summary>
        /// Get current cursor position in console screen
        /// </summary>
        /// <returns>Coordinates</returns>
        public static Structs.Coordinate GetCursor()
        {
            Structs.Coordinate retVal = new Structs.Coordinate();
            retVal.AxisPointX = Console.CursorLeft;
            retVal.AxisPointY = Console.CursorTop;
            return retVal;
        }
        public static void ConsoleTitle(string title)
        {
            Console.Title = title;
        }
        /// <summary>
        /// Miximaize the application console window. Strech to the corners of the desktop window.
        /// </summary>
        public static void Miximaize()
        {
            [System.Runtime.InteropServices.DllImport("kernel32.dll", ExactSpelling = true)]

            static extern IntPtr GetConsoleWindow();
            IntPtr ThisConsole = GetConsoleWindow();

            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]

            static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
            const int HIDE = 0;
            const int MAXIMIZE = 3;
            const int MINIMIZE = 6;
            const int RESTORE = 9;

            ShowWindow(ThisConsole, MAXIMIZE);
        }
        /// <summary>
        /// Moving the application console window. base on the parameters below
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void Move(int locationX, int locationY, int width, int height)
        {
            [System.Runtime.InteropServices.DllImport("kernel32.dll", ExactSpelling = true)]

            static extern IntPtr GetConsoleWindow();
            IntPtr ThisConsole = GetConsoleWindow();

            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]

            static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

            MoveWindow(ThisConsole, locationX, locationY, width, height, false);
        }


        #endregion Public Methods
    }
}
