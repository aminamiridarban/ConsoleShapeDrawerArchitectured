
namespace ConsoleShapeDrawerArchitectured.Abstractions.Services
{
    public abstract class DrawServiceBase<Model> :
        Interfaces.Services.IDrawService<Model>
        where Model : Interfaces.Feature.IDrawable
    {
        protected DrawServiceBase()
        {
        }

        protected virtual void Draw(Model shape)
        {
            if (!shape.IsDrawable())
            {
                Console.WriteLine(Resources.MessageResource.UnDrawableShape);
                return;
            }
        }

        void Interfaces.Services.IDrawService<Model>.Draw(Model shape)
        {
            this.Draw(shape);
        }
    }
}
