using Microsoft.Extensions.Logging;

namespace ConsoleShapeDrawerArchitectured.Services.StoreServices
{
    public sealed class StoreRectangleService : Abstractions.Services.StoreServiceBase<Abstractions.Shapes.RectangleBase>
    {
        public StoreRectangleService(ILogger<Program> logger, Models.Rectangle rectangle, string path, string filename)
            : base(path, filename)
        {
            try
            {
                DrawServices.DrawRectangleService d = new DrawServices.DrawRectangleService();
                StoreInFile(d.DrawString(rectangle));
            }
            catch (Exception ex)
            {
                string errLog = $"An Exception raised with message : {ex.Message}, stackTrace : {ex.StackTrace}";
                logger.LogError(ex, errLog);
            }
        }
        protected override void StoreInFile(string rectangleDrawString)
        {
            base.StoreInFile(rectangleDrawString);
        }
    }
}
