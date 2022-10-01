
namespace ConsoleShapeDrawerArchitectured.Interfaces.Services
{
    public interface IDrawService<Model> where Model :
         Feature.IDrawable
    {
        void Draw(Model shape);
    }
}
