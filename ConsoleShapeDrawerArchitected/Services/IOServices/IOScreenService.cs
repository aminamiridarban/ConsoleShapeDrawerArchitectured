using Microsoft.Extensions.Logging;

namespace ConsoleShapeDrawerArchitectured.Services.IOServices
{
    public class IOScreenService : Abstractions.Services.IOServiceBase
    {
        public IOScreenService(ILogger<Program>? logger) : base(logger)
        {
        }
    }
}
