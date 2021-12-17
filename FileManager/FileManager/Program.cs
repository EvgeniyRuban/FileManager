using System.IO;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(@"C:\Users\zheka\OneDrive\Рабочий стол");
            FileManager fileManager = new FileManager();
            fileManager.Run();
        }
    }
}

