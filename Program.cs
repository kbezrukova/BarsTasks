//1 задание
using System;
using System.IO;
using System.Management.Automation.Language;
//я не знаю правильно ли, но я вложила в это душу..
namespace Барс1
{
    class Program
    {
        static void Main(string[] args)
        {
            string textFile= @"C:\Users\1\source\repos\Барс1\Барс1\bars1.txt";
            LocalFileLogger<string> test1 = new LocalFileLogger<string>(textFile);
            test1.LogInfo("Hello");
            test1.LogWarning("Stop");
            Exception ex = new Exception("Unknown exception");
            test1.LogError("Ex", ex);

            LocalFileLogger<byte> test2 = new LocalFileLogger<byte>(textFile);
            test2.LogInfo("Hello, hello!!!");
            test2.LogWarning("Stop!!!");
            Exception ex2 = new Exception("Unknown exception...");
            test2.LogError("Ex", ex);
        }
    }

    public interface ILogger
    {
        public void LogInfo(string message);
        public void LogWarning(string message);
        public void LogError(string message, Exception ex);
    }
    public class LocalFileLogger<T> : ILogger
    {
        private string path;
        public LocalFileLogger(string pathToFile)
        {
            path = Path.GetFullPath(pathToFile);
        }
        string GenericTypeName=typeof(T).Name;
        public void LogInfo(string message)
        {
            File.AppendAllText(path, $"[Info]: [{GenericTypeName}] : {message}" +Environment.NewLine);
        }
        public void LogWarning(string message)
        {
            File.AppendAllText(path, $"[Warning] : [{GenericTypeName}] : {message}" + Environment.NewLine);
        }
        public void LogError(string message, Exception ex)
        {
            File.AppendAllText(path, $"[Error] : [{GenericTypeName}] : {message}. {ex.Message}" + Environment.NewLine);
        }
    }
}
