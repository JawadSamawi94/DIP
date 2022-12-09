namespace DIP.Models
{
    public abstract class LogBase
    {
        public abstract void Log(string message);
    }

    public class FileLogger : LogBase
    {
        public string filePath = @"../DIP/Logs/Logs.txt";
        public override void Log(string message)
        {
            var msg = $"{DateTime.Now.ToString()} --> {message} {Environment.NewLine}";
            File.AppendAllText(filePath, msg);
        }
    }
}
