namespace TranslateFun
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using RavSoft.GoogleTranslator;

    public class MegaTranslator
    {
        private static readonly List<string> Languages = new List<string> { "Chinese", "French", "Spanish", "Chinese", "German", "Dutch" };

        public async Task<string> TranslateLotsOfTimesAsync(string text)
        {
            var translator = new Translator();
            var from = string.Empty;
            var firstGo = true;

            foreach (var to in LanguagesIncludingEnglish())
            {
                if (firstGo)
                {
                    from = to;
                    firstGo = false;
                    continue;
                }
                
                text = await translator.Translate(text, from, to);
                from = to;
            }

            return text;
        }

        private static List<string> LanguagesIncludingEnglish()
        {
            var startLanguage = "English";
            var languages = new List<string> { startLanguage, startLanguage };
            languages.InsertRange(1, Languages);
            return languages;
        }
    }
}