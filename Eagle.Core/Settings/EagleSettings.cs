using Eagle.Core.Helpers;
using Eagle.Core.Statics;
using System.Runtime;

namespace Eagle.Core.Settings
{
    public class EagleSettings
    {
        private static EagleSettings _instance;
        public static EagleSettings Instance
        {
            get
            {
                if(_instance is null)
                    _instance = CreateInstance();
                return _instance;
            }
        }
        private EagleSettings()
        {
            
        }
        private static EagleSettings CreateInstance()
        {
            const string directoryName = @"\settings\eagle.settings.json";
            var json = TextFileReader.ReadAsStringAsync(Path.Combine(AppSettings.CurrentDirectory, directoryName)).Result; 
            return JsonSerializerHelper.Deserialize<EagleSettings>(json)!;
        }


        public DatabaseSettings DatabaseSetting { get; set; }


        public class DatabaseSettings
        {
            public string EagleDbConnectionString { get; set; }
        }
    }
}
