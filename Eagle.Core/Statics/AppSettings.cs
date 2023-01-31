namespace Eagle.Core.Statics
{
    public class AppSettings
    {
        public static string CurrentDirectory => AppDomain.CurrentDomain.BaseDirectory;
        public static string Directory(string directory)
        {
            return Path.Combine(CurrentDirectory, directory);
        }
    }
}
