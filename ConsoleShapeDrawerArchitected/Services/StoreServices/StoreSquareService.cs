using Microsoft.Extensions.Logging;

namespace ConsoleShapeDrawerArchitectured.Services.StoreServices
{
    public sealed class StoreSquareService : Abstractions.Services.StoreServiceBase<Abstractions.Shapes.SquareBase>
    {
        public StoreSquareService(ILogger<Program> logger, Models.Square square, string path, string filename)
            : base(path, filename)
        {
            try
            {
                DrawServices.DrawSquareService d = new DrawServices.DrawSquareService();
                StoreInFile(d.DrawString(square));
            }
            catch (Exception ex)
            {
                string errLog = $"An Exception raised with message : {ex.Message}, stackTrace : {ex.StackTrace}";
                logger.LogError(ex, errLog);
            }
        }
        protected override void StoreInFile(string squareDrawString)
        {
            base.StoreInFile(squareDrawString);
        }
    }
}
