
using ConsoleShapeDrawerArchitectured.Utilities;
using Microsoft.Extensions.Logging;



namespace ConsoleShapeDrawerArchitectured
{
    public class Program
    {
        private readonly static List<Enums.ShapeTypes> Shapes = Extentions.EnumValues<Enums.ShapeTypes>().Reverse().ToList();
        private readonly static List<Enums.OutPutTypes> OutPuts = Extentions.EnumValues<Enums.OutPutTypes>().Reverse().ToList();
        private readonly static Services.IOServices.IOScreenService screen = new Services.IOServices.IOScreenService(_logger);
        public static ILogger<Program> _logger;

        Program(ILogger<Program> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Starting up the application
        /// </summary>
        /// <param name="args"></param>
        /// <exception cref="IOException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        static void Main(string[] args)
        {
            _logger = LoggingSettingUp();
            try
            {
                ApplicationInitialization();
            }
            catch (IOException ex)
            {
                string errLog = $"This is an I/O Exception raised with message : {ex.Message}, stackTrace : {ex.StackTrace}";
                _logger.LogError(ex, errLog);
                throw new IOException(errLog);
            }
            catch (ArgumentNullException ex)
            {
                string errLog = $"This is an ArgumentNull Exception raised with message : {ex.Message}";
                _logger.LogError(ex, errLog);
                throw new ArgumentNullException(errLog);
            }
            catch (ArgumentException ex)
            {
                string errLog = $"This is an Argument Exception raised with innerException : {ex.InnerException}";
                _logger.LogError(ex, errLog);
                throw new ArgumentException(errLog);
            }
            catch (Exception ex)
            {
                string errLog = ex.Message;
                _logger.LogError(ex, errLog);
                throw new Exception(errLog);
            }

            Console.Read();

        }
        /// <summary>
        /// Runs at the applicaation start to handle application User Interface. 
        /// </summary>
        private static void ApplicationInitialization()
        {
            try
            {
                //Initilizing console screen setup and make console ready for application.
                ConsoleScreen.Miximaize();
                ConsoleScreen.BackgroundColor = ConsoleColor.Black;
                ConsoleScreen.ForegroundColor = ConsoleColor.Green;

                screen.Clear();
                screen.NextLine(3);
                screen.WriteLine(Resources.MessageResource.Author);
                screen.NextLine(2);

                //Say hello & welcome to user
                screen.WriteLine(Resources.MessageResource.WelcomeMessage);
                screen.NextLine(2);

                //Is user ready to start application or just wants to exit
                if (DoesUserWantsToContinue())
                    StartUserInterfaceInConsole();
                else
                    screen.Exit();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
        /// <summary>
        /// Checks if user wants to continue working with application or not.
        /// </summary>
        private static bool DoesUserWantsToContinue()
        {
            bool retVal = false;

            screen.WriteInColor(Resources.MessageResource.ContinueMessage, ConsoleColor.DarkBlue);
            screen.WriteInColor(Resources.MessageResource.SeparatorChar, 7, ConsoleColor.DarkBlue);
            var userOpinion = screen.ReadKey();
            try
            {
                if (userOpinion.IsEnterKey())
                    retVal = true;
                else if (userOpinion.IsEscapeKey())
                    retVal = false;
                else
                {
                    screen.WriteLineInColor(Resources.MessageResource.UnKnownKey, ConsoleColor.Yellow);
                    screen.NextLine(1);
                    screen.WriteLine(Resources.MessageResource.TryAgainMessage);
                    retVal = DoesUserWantsToContinue();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{Environment.NewLine}An Error Occures:::»{Environment.NewLine} Message : {ex.Message}{Environment.NewLine}");
            }
            return retVal;
        }
        /// <summary>
        /// Trying to comniucate with user through instructions which are provide application performance.
        /// </summary>
        private static void StartUserInterfaceInConsole()
        {
            Enums.ShapeTypes selectedShape = ShapeSelectionUI();
            if (selectedShape is not Enums.ShapeTypes.None)
            {
                Interfaces.Feature.IDrawable? drawableShape = GatheringShapeDrawingPrerestiquiesUI(selectedShape);
                if (drawableShape is not null)
                {
                    Enums.OutPutTypes selectedOutPut = OutPutSelectionUI();
                    PresentRequestedShapeOutPut(selectedShape, drawableShape, selectedOutPut);
                }
            }

        }
        /// <summary>
        /// Produce appropriate OutPut for the requested shape base on user output type selection
        /// </summary>
        /// <param name="selectedShape"></param>
        /// <param name="drawableShape"></param>
        /// <param name="selectedOutPut"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private static void PresentRequestedShapeOutPut(Enums.ShapeTypes selectedShape, Interfaces.Feature.IDrawable drawableShape, Enums.OutPutTypes selectedOutPut)
        {
            switch (selectedOutPut)
            {
                case Enums.OutPutTypes.None:
                    StartUserInterfaceInConsole();
                    break;
                case Enums.OutPutTypes.Draw:
                    screen.WriteLine(Resources.MessageResource.StartDrawingMessage);
                    screen.NextLine(1);
                    Functions.DrawShape(drawableShape, _logger);
                    screen.NextLine(1);
                    break;
                case Enums.OutPutTypes.Store:
                    Functions.StoreShape(drawableShape, _logger);
                    screen.WriteInColor(
                        $"{drawableShape.Title} stored successfully, Currently at {Path.GetDirectoryName(Environment.GetCommandLineArgs()[0])}\\{drawableShape.Name}.txt"
                        , ConsoleColor.Yellow
                        );
                    screen.NextLine(2);
                    break;
                case Enums.OutPutTypes.Calculations:
                    ShapeComputationsUI(selectedShape, drawableShape);
                    break;
                default:
                    _logger.LogCritical(Resources.MessageResource.UnexpectedError, drawableShape);
                    throw new ArgumentOutOfRangeException($"{Resources.MessageResource.UnexpectedError} param name {drawableShape.Name}");
            }
            screen.Write(Resources.MessageResource.SeparatorChar, 20);
            if (DoesUserWantsToContinue())
                PresentRequestedShapeOutPut(selectedShape, drawableShape, OutPutSelectionUI());
            else
                screen.Exit();
            screen.NextLine(1);
        }
        /// <summary>
        /// Produce Output UI for the requested shape 
        /// </summary>
        /// <param name="selectedShape"></param>
        /// <param name="drawableShape"></param>
        private static void ShapeComputationsUI(Enums.ShapeTypes selectedShape, Interfaces.Feature.IDrawable drawableShape)
        {
            screen.WriteLineInColor($"{Resources.MessageResource.OutPutMessage}{Resources.MessageResource.ArrowDownLetter}", ConsoleColor.DarkRed);
            screen.NextLine(1);
            screen.WriteLineInColor($"{selectedShape} With:", ConsoleColor.Red);
            screen.NextLine(1);
            foreach (var property in drawableShape.GetProperties().GetRequireds().WithIndex())
            {
                screen.WriteLineInColor($"#{property.index + 1} - {property.item} = {property.item.GetValue(drawableShape)}", ConsoleColor.DarkYellow);
                screen.NextLine(1);
            }
            List<string> computationResults = Functions.PrintShapeComputations(drawableShape);
            foreach (string computationResult in computationResults)
            {
                screen.WriteLineInColor(computationResult, ConsoleColor.DarkYellow);
                screen.NextLine(1);
            }
        }
        /// <summary>
        /// Gathering Required parameters to invoke appropriate class base on selectedShape
        /// </summary>
        /// <param name="selectedShape"></param>
        private static Interfaces.Feature.IDrawable? GatheringShapeDrawingPrerestiquiesUI(Enums.ShapeTypes selectedShape)
        {
            Interfaces.Feature.IDrawable? retVal = null;
            if (selectedShape != Enums.ShapeTypes.None)
            {
                screen.WriteLineInColor($" Congratulations, You Chose {selectedShape}..!", ConsoleColor.DarkYellow);
                screen.NextLine(1);
                screen.WriteLineInColor($"{selectedShape.DrawingPrerestiquies()}", ConsoleColor.DarkYellow);
                screen.NextLine(1);
                screen.WriteInColor(Resources.MessageResource.SeparatorChar, 45, ConsoleColor.Blue);
                screen.WriteLineInColor(Resources.MessageResource.DimensionsMessage, ConsoleColor.Blue);
                screen.NextLine(1);

                object? selectedShapeInstance = selectedShape.ReflectShapeInstanceByShapeType();

                if (selectedShapeInstance is not null)
                {
                    //Gathering the list of class properties
                    List<System.Reflection.PropertyInfo> selectedShapeTypeProperties = selectedShapeInstance.GetProperties();
                    //Filter properties base on required attribute
                    var requiredSelectedShapeTypeProperties = selectedShapeTypeProperties.GetRequireds();

                    foreach (var property in requiredSelectedShapeTypeProperties.WithIndex())
                    {
                        string name = property.item.Name;
                        string type = property.item.PropertyType.Name;
                        string? displayName = string.Empty;
                        Structs.Range range = new Structs.Range();
                        string? rangeString = string.Empty;


                        //gets property display name by Display attribute
                        displayName = property.item.DisplayAttributeFromResources();


                        //gets property input value range by Range attribute
                        range = property.item.RangeAttributeInByte();
                        rangeString = $"Between '{range.MinValue}' AND '{range.MaxValue}'";

                        //Try Get the valid value for represented value in screen, from user input
                        try
                        {
                            byte userInputValue;
                            screen.NextLine(1);
                            screen.WriteLineInColor($"{property.index + 1}) - {displayName}, {Resources.MessageResource.NeedsValue} [{type}] {rangeString}", ConsoleColor.DarkRed);

                            while (
                                !byte.TryParse(screen.Readline(), out userInputValue) ||
                                (range.MinValue == null || userInputValue < range.MinValue) ||
                                (range.MaxValue == null || userInputValue > range.MaxValue)
                                )
                            {
                                screen.WriteLine($"{Resources.MessageResource.UnValidInput}");
                                screen.NextLine(1);
                                screen.WriteLineInColor(Resources.MessageResource.TryAgainMessage, ConsoleColor.Blue);
                                screen.WriteLineInColor($"{property.index + 1}) - {displayName}, {Resources.MessageResource.NeedsValue} [{type}] {rangeString}", ConsoleColor.Red);
                            }
                            //Set retrived Value to property
                            property.item.SetValue(selectedShapeInstance, userInputValue);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }

                    }
                }

                retVal = (Interfaces.Feature.IDrawable?)selectedShapeInstance;

            }
            return retVal;
        }
        /// <summary>
        /// Gathering user selection to which shape wants to draw
        /// </summary>
        private static Enums.ShapeTypes ShapeSelectionUI()
        {
            //Drawing User Interface to choose Shape Selection

            screen.Write(Resources.MessageResource.SeparatorChar, 12);
            screen.Write(Resources.MessageResource.AvailableShapesMessage);
            screen.NextLine(2);

            foreach (Enums.ShapeTypes Shape in Shapes)
            {
                if (Shape.GetByteValue() == 0)
                    screen.NextLine(1);
                screen.WriteLineInColor(Shape.AsStringItem(), ConsoleColor.Magenta);
            }
            screen.NextLine(1);
            screen.WriteLine(Resources.MessageResource.SeparatorChar, 60);
            //Reading User Sellection from user interface
            ConsoleKeyInfo? selection = screen.ReadKey();
            return ShapeSelectionUIResult(selection);
        }
        /// <summary>
        /// Produce appropriate UI Result and configuring next step base on user input for ShapeSelectionUI
        /// </summary>
        private static Enums.ShapeTypes ShapeSelectionUIResult(ConsoleKeyInfo? selection)
        {
            Enums.ShapeTypes retval = Enums.ShapeTypes.None;

            //Reading User Sellection from user interface
            ConsoleKeyInfo? selectedShape = selection.HasValue ? selection : screen.ReadKey();

            if (//Check if entered key has value and that is a number or letter
                !selectedShape.HasValue
                ||
                !Char.IsLetterOrDigit(selectedShape.Value.KeyChar)
                )
            {
                screen.WriteLineInColor(Resources.MessageResource.UnKnownKey, ConsoleColor.Yellow);
                screen.NextLine();
                screen.WriteLine(Resources.MessageResource.TryAgainMessage);
                retval = ShapeSelectionUIResult(null);
            }
            else if
                (//Check if enetred key is Enums.ShapeTypes.None or not.
                selectedShape.Value.Key.ToString() == Enums.ShapeTypes.None.DefaultValueAttribute()
                ||
                selectedShape.Value.KeyChar.GetNumberFromKeyValue() == Enums.ShapeTypes.None.GetByteValue()
                )//Check if user confirms the ignoration or wants to continue.
                if (ShowConfirmationMessage())
                    screen.Exit();
                else
                    retval = ShapeSelectionUI();
            else if (//Check if entered key is not a valid value for shapes bye number or first letter
                !Shapes.Any(s => s.GetByteValue() == selectedShape.Value.KeyChar.GetNumberFromKeyValue())
                &&
                !Shapes.Any(s => s.DefaultValueAttribute() == selectedShape.Value.Key.ToString())
                )
            {
                screen.WriteInColor(Resources.MessageResource.UnKnownShape, ConsoleColor.Yellow);
                screen.NextLine(1);
                screen.WriteLine(Resources.MessageResource.TryAgainMessage);

                retval = ShapeSelectionUIResult(null);
            }
            else
            {//Write down the name of selected shape
                retval = Shapes.FirstOrDefault(s =>
                    s.GetByteValue() == selectedShape.Value.KeyChar.GetNumberFromKeyValue()
                    ||
                    s.DefaultValueAttribute() == selectedShape.Value.Key.ToString()
                    );
            }

            return retval;

        }
        /// <summary>
        /// Gathering user selection to which output type is desire
        /// </summary>
        private static Enums.OutPutTypes OutPutSelectionUI()
        {
            //Drawing User Interface to choose Output Selection

            screen.Write(Resources.MessageResource.SeparatorChar, 12);
            screen.Write(Resources.MessageResource.AvailableOutPutMessage);
            screen.NextLine(2);

            foreach (Enums.OutPutTypes Output in OutPuts)
            {
                if (Output.GetByteValue() == 0)
                    screen.NextLine(1);
                screen.WriteLineInColor(Output.AsStringItem(), ConsoleColor.Magenta);
            }
            screen.NextLine(1);
            screen.WriteLine(Resources.MessageResource.SeparatorChar, 60);
            //Reading User Sellection from user interface
            ConsoleKeyInfo? selection = screen.ReadKey();
            return OutPutSelectionUIResult(selection);
        }
        /// <summary>
        /// Produce appropriate UI Result and configuring next step base on user input for OutPutSelectionUI
        /// </summary>
        private static Enums.OutPutTypes OutPutSelectionUIResult(ConsoleKeyInfo? selection)
        {
            Enums.OutPutTypes retval = Enums.OutPutTypes.None;

            //Reading User Sellection from user interface
            ConsoleKeyInfo? selectedOutput = selection.HasValue ? selection : screen.ReadKey();

            if (//Check if entered key has value and that is a number or letter
                !selectedOutput.HasValue
                ||
                !Char.IsLetterOrDigit(selectedOutput.Value.KeyChar)
                )
            {
                screen.WriteLineInColor(Resources.MessageResource.UnKnownKey, ConsoleColor.Yellow);
                screen.NextLine();
                screen.WriteLine(Resources.MessageResource.TryAgainMessage);
                retval = OutPutSelectionUIResult(null);
            }
            else if
                (//Check if enetred key is Enums.OutPutTypes.None or not.
                selectedOutput.Value.Key.ToString() == Enums.OutPutTypes.None.DefaultValueAttribute()
                ||
                selectedOutput.Value.KeyChar.GetNumberFromKeyValue() == Enums.OutPutTypes.None.GetByteValue()
                )//Check if user confirms the ignoration or wants to continue.
                if (ShowConfirmationMessage())
                    return Enums.OutPutTypes.None;
                else
                    retval = OutPutSelectionUI();
            else if (//Check if entered key is not a valid value for output bye number or first letter
                !OutPuts.Any(s => s.GetByteValue() == selectedOutput.Value.KeyChar.GetNumberFromKeyValue())
                &&
                !OutPuts.Any(s => s.DefaultValueAttribute() == selectedOutput.Value.Key.ToString())
                )
            {
                screen.WriteInColor(Resources.MessageResource.UnKnownOutPut, ConsoleColor.Yellow);
                screen.NextLine(1);
                screen.WriteLine(Resources.MessageResource.TryAgainMessage);

                retval = OutPutSelectionUIResult(null);
            }
            else
            {//Write down the name of selected shape
                retval = OutPuts.FirstOrDefault(s =>
                    s.GetByteValue() == selectedOutput.Value.KeyChar.GetNumberFromKeyValue()
                    ||
                    s.DefaultValueAttribute() == selectedOutput.Value.Key.ToString()
                    );
            }

            return retval;

        }
        /// <summary>
        /// Perform approprite action base on user confirms the ignoration or not
        /// </summary>
        private static bool ShowConfirmationMessage()
        {
            bool retVal = false;
            screen.NextLine();
            screen.WriteLineInColor(Resources.MessageResource.ConfirmationMessage);
            //Reading User Sellection from user interface
            ConsoleKeyInfo? confirmation = screen.ReadKey();
            char confirmationDecision = confirmation.Value.Key.ToString().ToLower().First();
            if (//Check if entered key has value and that is a letter
                !confirmation.HasValue
                ||
                !Char.IsLetter(confirmation.Value.KeyChar)
                ||
                (//Check if entered key is not a valid letter for confirmation(y/n)
                confirmationDecision != 'y'
                &&
                confirmationDecision != 'n'
                )
                )
            {
                screen.WriteLineInColor(Resources.MessageResource.UnKnownKey, ConsoleColor.Yellow);
                screen.NextLine(1);
                screen.WriteLine(Resources.MessageResource.TryAgainMessage);

                retVal = ShowConfirmationMessage();
            }
            else
            {
                if (confirmation.Value.Key.ToString().ToLower() == "y")
                    retVal = true;
                else
                    retVal = false;
            }
            return retVal;
        }

        /// <summary>
        /// Configuring Logger for Console
        /// </summary>
        /// <returns></returns>
        private static ILogger<Program> LoggingSettingUp()
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Error)
                    .AddFilter("InterviewConsoleShapesApp.Program", LogLevel.Critical)
                    .AddFilter("InterviewConsoleShapesApp.Program", LogLevel.Error)
                    .AddConsole();
            });
            return loggerFactory.CreateLogger<Program>();
        }
    }
}