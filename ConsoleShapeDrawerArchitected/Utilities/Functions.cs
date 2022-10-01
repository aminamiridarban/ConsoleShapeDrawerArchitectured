using Microsoft.Extensions.Logging;

namespace ConsoleShapeDrawerArchitectured.Utilities
{
    public static class Functions
    {
        public static void DrawShape(Interfaces.Feature.IDrawable drawableShape, ILogger<Program> logger)
        {
            Type shapeType = drawableShape.GetType();
            // scan for the class type
            var serviceType = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                               from t in assembly.GetTypes()
                               where t.Name == $"Draw{shapeType.Name}Service"  // you could use the t.FullName as well
                               select t).FirstOrDefault();

            if (serviceType == null)
                throw new InvalidOperationException($"Draw {shapeType.Name} Type Service not found");
            else
                Activator.CreateInstance(serviceType, logger, drawableShape);
        }

        public static void StoreShape(Interfaces.Feature.IDrawable drawableShape, ILogger<Program> logger)
        {
            StoreShape(logger, drawableShape, Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]), drawableShape.Title);
        }

        public static void StoreShape(ILogger<Program> logger, Interfaces.Feature.IDrawable drawableShape, string path, string fileName)
        {
            Type shapeType = drawableShape.GetType();
            // scan for the class type
            var serviceType = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                               from t in assembly.GetTypes()
                               where t.Name == $"Store{shapeType.Name}Service"  // you could use the t.FullName as well
                               select t).FirstOrDefault();

            if (serviceType == null)
                throw new InvalidOperationException($"Store {shapeType.Name} Type Service not found");
            else
                Activator.CreateInstance(serviceType, logger, drawableShape, path, fileName);
        }

        public static List<string> PrintShapeComputations(Interfaces.Feature.IDrawable drawableShape)
        {
            List<string> retVal = new List<string>();
            try
            {
                Type shapeType = drawableShape.GetType();

                System.Reflection.MethodInfo[] methods = shapeType.GetMethods()// returns only methods that have the InvokeAttribute;
                    .Where(x => x.GetCustomAttributes(typeof(Attributes.InvokeAttribute), false).FirstOrDefault() != null).ToArray();
                if (methods.Any())
                    // iterate through all found methods
                    foreach (var method in methods)
                    {
                        if (method != null)
                        {
                            // Instantiate the class
                            var hasParameterlessConstructor = shapeType.GetConstructor(Type.EmptyTypes) != null;
                            if (!shapeType.IsInterface && hasParameterlessConstructor)
                            {
                                var instantiatedMethod = Activator.CreateInstance(method.ReflectedType);
                                // invoke the method                                                                                                 
                                var result = method.Invoke(drawableShape, null);
                                if (result != null)
                                    retVal.Add($"{method.Name} » {result}");
                            }
                        }
                    }
            }
            catch (Exception ex)
            {
                throw new MethodAccessException(ex.Message);
            }
            return retVal;
        }

    }
}
