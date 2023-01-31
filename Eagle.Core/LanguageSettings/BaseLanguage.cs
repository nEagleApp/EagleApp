using Eagle.Core.Helpers;
using Eagle.Core.LanguageSettings.Implementations;
using Eagle.Core.Settings;
using Eagle.Core.Statics;
using Eagle.Core.Statics.Enums;

namespace Eagle.Core.LanguageSettings
{
    public class BaseLanguage
    {
        public static async Task<ILanguage> GetLanguage(Language languageEnum)
        {
            return await LangugaeGenerator(languageEnum);
        }
        public static async Task<ILanguage> GetLanguage(int language)
        {
            return await LangugaeGenerator((Language)language);
        }
        private static async Task<ILanguage> LangugaeGenerator(Language languageEnum)
        {
            ILanguage language;
            switch (languageEnum)
            {
                case Language.English:
                    {
                        var json = await TextFileReader.ReadAsStringAsync(EnglishLanguage.DirectoryPath);
                        language = JsonSerializerHelper.Deserialize<EnglishLanguage>(json)!;
                        break;
                    }
                default:
                    {
                        var json = await TextFileReader.ReadAsStringAsync(EnglishLanguage.DirectoryPath);
                        language = JsonSerializerHelper.Deserialize<EnglishLanguage>(json)!;
                        break;
                    }
            }
            return language;
        }
    }
}
