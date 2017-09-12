namespace TranslateFun
{
    using System.Threading.Tasks;

    using RavSoft.GoogleTranslator;

    public class MegaTranslator
    {
        public async Task<string> TranslateLotsOfTimesAsync(string text, int numberOfTimesToTranslate)
        {
            return await Translate(text, numberOfTimesToTranslate);
        }

        private static async Task<string> Translate(string text, int numberOfTimesToTranslate)
        {
            var translator = new Translator();

            for (var i = 0; i < numberOfTimesToTranslate; i++)
            {
                var chinese = await translator.Translate(text, "English", "Chinese");
                text = await translator.Translate(chinese, "Chinese", "English");
            }

            return text;
        }
    }
}