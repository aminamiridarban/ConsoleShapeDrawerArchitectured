
namespace ConsoleShapeDrawerArchitectured.Abstractions.Services
{
    public abstract class StoreServiceBase<Model> :
        Interfaces.Services.IStoreService
        where Model : Interfaces.Feature.IDrawable
    {
        private string _path;
        private string _fileName;

        public string Path { get => _path; set => _path = value; }
        public string FileName { get => _fileName; set => _fileName = value; }

        protected StoreServiceBase(string path, string filename)
        {
            _path = path;
            _fileName = filename;
        }

        void Interfaces.Services.IStoreService.StoreInFile(string shapeDrawString)
        {
            this.StoreInFile(shapeDrawString);
        }
        protected virtual void StoreInFile(string shapeDrawString)
        {
            string fileName = $"{_path}\\{_fileName}.txt";

            if (string.IsNullOrEmpty(_path) || string.IsNullOrEmpty(_fileName)) throw new ArgumentNullException("args");

            //Create the file
            var file = new FileStream(fileName, FileMode.OpenOrCreate);
            //Save the standard output
            var standardOutput = Console.Out;
            //Create a StreamWriter
            using (var writer = new StreamWriter(file))
            {
                //Set the new output
                Console.SetOut(writer);
                //Write something
                Console.WriteLine(shapeDrawString);
                //Change the ouput again
                Console.SetOut(standardOutput);
            }
        }
    }
}
