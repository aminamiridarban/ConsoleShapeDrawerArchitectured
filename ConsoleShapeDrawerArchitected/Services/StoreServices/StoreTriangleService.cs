using Microsoft.Extensions.Logging;

namespace ConsoleShapeDrawerArchitectured.Services.StoreServices
{
    public sealed class StoreTriangleService : Abstractions.Services.StoreServiceBase<Abstractions.Shapes.TriangleBase>
    {
        public StoreTriangleService(ILogger<Program> logger, Models.Triangle triangle, string path, string filename)
           : base(path, filename)
        {
            try
            {
                DrawServices.DrawTriangleService d = new DrawServices.DrawTriangleService();
                StoreInFile(d.DrawString(triangle));
            }
            catch (Exception ex)
            {
                string errLog = $"An Exception raised with message : {ex.Message}, stackTrace : {ex.StackTrace}";
                logger.LogError(ex, errLog);
            }
        }
        protected override void StoreInFile(string triangleDrawString)
        {
            base.StoreInFile(triangleDrawString);
        }
    }
}
