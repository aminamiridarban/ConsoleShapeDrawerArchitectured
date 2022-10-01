
namespace ConsoleShapeDrawerArchitectured.Interfaces.Services
{
    public interface IIOService
    {
        void Exit();
        void Clear();
        object? Read();
        string? Readline();
        ConsoleKeyInfo ReadKey();
        void WriteInColor(object args, ConsoleColor? foreground = null, ConsoleColor? background = null);
        Utilities.Enums.ShapeTypes ReadSelectedShape();
        void Write(object w, byte? i);
        void WriteLine(object w, byte? i);
        void Write(object w);
        void WriteLine(object w);
        void NextLine(byte? lines);
        bool IsEnterKey();
        bool IsEscapeKey();
    }
}
