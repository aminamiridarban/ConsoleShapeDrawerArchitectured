using Microsoft.Extensions.Logging;
using ConsoleShapeDrawerArchitectured.Utilities;

namespace ConsoleShapeDrawerArchitectured.Abstractions.Services
{
    public class IOServiceBase : Interfaces.Services.IIOService
    {
        private readonly ILogger<Program>? _logger;
        public IOServiceBase(ILogger<Program>? logger)
        {
            _logger = logger;
        }

        /// <summary>
        ///  Writes the text representation of the specified value, followed
        ///   by the current line terminator itrated to lines
        /// </summary>
        /// <param name="w"></param>
        /// <param name="i"></param>
        public virtual void Write(object w, byte? i)
        {
            try
            {
                while (i > 0)
                {
                    Write(w);
                    i--;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, _logger.ToString());
            }
        }
        /// <summary>
        /// Writes w param directly into the consol.
        /// </summary>
        /// <param name="w"></param>
        public virtual void Write(object w)
        {
            try
            {
                Console.Write(w);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, _logger.ToString());
            }
        }
        /// <summary>
        /// go to next line
        /// </summary>
        public virtual void NextLine(byte? i = 0)
        {
            try
            {
                Write(Environment.NewLine, i);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, _logger.ToString());
            }
        }
        /// <summary>
        ///  Writes the text representation of the specified value, followed
        ///   by the current line terminator
        /// </summary>
        /// <param name="w"></param>
        public virtual void WriteLine(object w, byte? i)
        {
            try
            {
                while (i > 0)
                {
                    Write(w);
                    i--;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, _logger.ToString());
            }
        }
        /// <summary>
        ///  Writes the text representation of the specified value, followed
        ///   by the current line terminator
        /// </summary>
        /// <param name="w"></param>
        public virtual void WriteLine(object w)
        {
            try
            {
                Console.WriteLine(w);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, _logger.ToString());
            }
        }
        /// <summary>
        /// Reads the next character from the standard input stream.
        /// </summary>
        /// <returns></returns>
        public virtual object? Read()
        {
            try
            {
                return Console.Read();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, _logger.ToString());
            }
            return null;
        }
        /// <summary>
        /// Obtains the next character or function key pressed by the user. The pressed key
        ///is optionally displayed in the console window.
        /// </summary>
        /// <returns> 
        /// An object that describes the System.ConsoleKey constant and Unicode character,
        //     if any, that correspond to the pressed console key. The System.ConsoleKeyInfo
        //     object also describes, in a bitwise combination of System.ConsoleModifiers values,
        //     whether one or more Shift, Alt, or Ctrl modifier keys was pressed simultaneously
        //     with the console key.
        //     </returns>
        public virtual ConsoleKeyInfo ReadKey()
        {
            ConsoleKeyInfo retVal = new ConsoleKeyInfo();
            try
            {
                WriteLineInColor(Resources.MessageResource.KeyMessage, ConsoleColor.Blue);

                retVal = Console.ReadKey(true);

                WriteLineInColor($"{Environment.NewLine} {Resources.MessageResource.Pressed} " +
                    $" {Resources.MessageResource.ArrowLetter} {Environment.NewLine}" +
                    $" {Resources.MessageResource.ArrowDownLetter}{Environment.NewLine}" +
                    $" '{retVal.KeyChar.KeyCharRecognition()}'{Environment.NewLine} ", ConsoleColor.Blue);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, _logger.ToString());
            }
            return retVal;
        }
        /// <summary>
        ///  Obtains the next character or function key pressed by the user and determindes the key is Enter key
        /// </summary>
        /// <returns></returns>
        public virtual bool IsEnterKey()
        {
            try
            {
                var keyInput = ReadKey();
                return keyInput != null && ((ConsoleKeyInfo)keyInput).Key == ConsoleKey.Enter ? true : false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, _logger.ToString());
            }
            return false;
        }
        /// <summary>
        ///  Obtains the next character or function key pressed by the user and determindes the key is Esc key
        /// </summary>
        /// <returns></returns>
        public virtual bool IsEscapeKey()
        {
            try
            {
                var keyInput = ReadKey();
                return keyInput != null && ((ConsoleKeyInfo)keyInput).Key == ConsoleKey.Escape ? true : false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, _logger.ToString());
            }
            return false;
        }
        /// <summary>
        /// Reads the specific key from the user input and recognize the shape by key
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// Reads the specific key from the user input and recognize the shape by key
        /// </summary>
        /// <returns></returns>
        public virtual Enums.ShapeTypes ReadSelectedShape()
        {
            var retVal = Utilities.Enums.ShapeTypes.None;
            try
            {
                var keyInput = ReadKey();
                if (keyInput != null)
                    switch (((ConsoleKeyInfo)keyInput).Key)
                    {
                        case ConsoleKey.C:
                            retVal = Utilities.Enums.ShapeTypes.Circle;
                            break;
                        case ConsoleKey.S:
                            retVal = Utilities.Enums.ShapeTypes.Square;
                            break;
                        case ConsoleKey.R:
                            retVal = Utilities.Enums.ShapeTypes.Rectangle;
                            break;
                        case ConsoleKey.T:
                            retVal = Utilities.Enums.ShapeTypes.Triangle;
                            break;
                        default:
                            break;
                    }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, _logger.ToString());
            }
            return retVal;
        }
        // Summary:
        //     Reads the next line of characters from the standard input stream.
        //
        // Returns:
        //     The next line of characters from the input stream, or null if no more lines are
        //     available.
        //
        public virtual string? Readline()
        {
            string? retVal = null;
            try
            {
                WriteInColor(Resources.MessageResource.ValueMessage, ConsoleColor.Blue);

                retVal = Console.ReadLine();

                Console.WriteLine($"{Environment.NewLine} {Resources.MessageResource.Entered} " +
                    $" {Resources.MessageResource.ArrowLetter} {Environment.NewLine}" +
                    $" {Resources.MessageResource.ArrowDownLetter}{Environment.NewLine}" +
                    $" '{retVal}'{Environment.NewLine} ");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, _logger.ToString());
            }
            return retVal;
        }
        //Writes in special defined color for a moment
        public virtual void WriteInColor(object args, ConsoleColor? foreground = null, ConsoleColor? background = null)
        {
            ConsoleColor prevForeground = Console.ForegroundColor;
            ConsoleColor prevBackground = Console.BackgroundColor;
            Console.ForegroundColor = foreground.HasValue ? (ConsoleColor)foreground : prevForeground;
            Console.BackgroundColor = background.HasValue ? (ConsoleColor)background : prevBackground; ;
            Write(args);
            Console.ForegroundColor = prevForeground;
            Console.BackgroundColor = prevBackground;
            Console.Out.Flush();
        }
        public virtual void WriteInColor(object args, byte? i, ConsoleColor? foreground = null, ConsoleColor? background = null)
        {
            ConsoleColor prevForeground = Console.ForegroundColor;
            ConsoleColor prevBackground = Console.BackgroundColor;
            Console.ForegroundColor = foreground.HasValue ? (ConsoleColor)foreground : prevForeground;
            Console.BackgroundColor = background.HasValue ? (ConsoleColor)background : prevBackground; ;
            while (i > 0)
            {
                Write(args);
                i--;
            }
            Console.ForegroundColor = prevForeground;
            Console.BackgroundColor = prevBackground;
            Console.Out.Flush();
        }
        public virtual void WriteLineInColor(object args, byte? i, ConsoleColor? foreground = null, ConsoleColor? background = null)
        {
            ConsoleColor prevForeground = Console.ForegroundColor;
            ConsoleColor prevBackground = Console.BackgroundColor;
            Console.ForegroundColor = foreground.HasValue ? (ConsoleColor)foreground : prevForeground;
            Console.BackgroundColor = background.HasValue ? (ConsoleColor)background : prevBackground; ;
            while (i > 0)
            {
                WriteLine(args);
                i--;
            }
            Console.ForegroundColor = prevForeground;
            Console.BackgroundColor = prevBackground;
            Console.Out.Flush();
        }
        public virtual void WriteLineInColor(object args, ConsoleColor? foreground = null, ConsoleColor? background = null)
        {
            ConsoleColor prevForeground = Console.ForegroundColor;
            ConsoleColor prevBackground = Console.BackgroundColor;
            Console.ForegroundColor = foreground.HasValue ? (ConsoleColor)foreground : prevForeground;
            Console.BackgroundColor = background.HasValue ? (ConsoleColor)background : prevBackground; ;
            WriteLine(args);
            Console.ForegroundColor = prevForeground;
            Console.BackgroundColor = prevBackground;
            Console.Out.Flush();
        }
        /// <summary>
        /// Clear the whole console screen
        /// </summary>
        public virtual void Clear()
        {
            Console.Clear();
        }
        /// <summary>
        /// Resets the console colors
        /// </summary>
        public virtual void Reset()
        {
            Console.ResetColor();
        }
        /// <summary>
        /// Exiting current application.
        /// </summary>
        public virtual void Exit()
        {
            Write(Resources.MessageResource.GoodByeMessage);
            NextLine(1);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            for (int i = 0; i < 7; i++)
            {
                WriteLine(".");
                Thread.Sleep(800);
            }
            Environment.Exit(0);
        }
        /// <summary>
        /// Drawing a drawable shape into screen
        /// </summary>
        /// <param name="drawableShape"></param>
        /// <exception cref="InvalidOperationException"></exception>

    }
}
