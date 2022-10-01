using Microsoft.Extensions.Logging;

namespace ConsoleShapeDrawerArchitectured.Services.StoreServices
{
    public sealed class StoreCircleService : Abstractions.Services.StoreServiceBase<Abstractions.Shapes.CircleBase>
    {
        public static ILogger<Program>? _logger;
        public StoreCircleService(ILogger<Program> logger, Models.Circle circle, string path, string filename)
            : base(path, filename)
        {
            try
            {
                DrawServices.DrawCircleService d = new DrawServices.DrawCircleService();
                StoreInFile(d.DrawString(circle));
            }
            catch (Exception ex)
            {
                string errLog = $"An Exception raised with message : {ex.Message}, stackTrace : {ex.StackTrace}";
                logger.LogError(ex, errLog);
            }
        }
        protected override void StoreInFile(string circleDrawString)
        {
            base.StoreInFile(circleDrawString);
        }
    }
}
