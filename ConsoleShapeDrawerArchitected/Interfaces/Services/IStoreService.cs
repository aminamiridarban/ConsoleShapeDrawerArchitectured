
namespace ConsoleShapeDrawerArchitectured.Interfaces.Services
{
    public interface IStoreService
    {
        abstract string Path { get; set; }
        abstract string FileName { get; set; }
        abstract void StoreInFile(string shapeDrawString);
    }
}
