
using Eagle.Core.Statics;

namespace Eagle.Core.LanguageSettings.Implementations
{
    public class EnglishLanguage : BaseLanguage, ILanguage
    {
        public static string DirectoryPath => AppSettings.Directory(@"LanguageSettings\Resource\English.json");
        public string Test => jTest;




        public string jTest { get; set; }
    }
}
