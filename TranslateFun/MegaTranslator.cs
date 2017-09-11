namespace TranslateFun
{
    using RavSoft.GoogleTranslator;

    public class MegaTranslator
    {
        public string TranslateLotsOfTimes(string text, int numberOfTimesToTranslate)
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