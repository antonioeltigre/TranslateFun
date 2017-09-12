namespace TranslateFun
{
    using System.Threading.Tasks;

    using RavSoft.GoogleTranslator;

    public class MegaTranslator
    {
        public async Task<string> TranslateLotsOfTimesAsync(string text, int numberOfTimesToTranslate)
        {
            return await Task.Run(() => Translate(text, numberOfTimesToTranslate));
        }

        private static string Translate(string text, int numberOfTimesToTranslate)
        {
            var translator = new Translator();

            for (var i = 0; i < numberOfTimesToTranslate; i++)
            {
                var chinese = translator.Translate(text, "English", "Chinese");
                text = translator.Translate(chinese, "Chinese", "English");
            }

            return text;
        }
    }
}