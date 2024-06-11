// TransliterationClient/DirectTransliterationClient.cs
using TransliterationLib;

namespace TransliterationClient
{
    public class DirectTransliterationClient : ITransliterationClient
    {
        private readonly Transliterator _transliterator;

        public DirectTransliterationClient()
        {
            _transliterator = new Transliterator();
        }

        public string Transliterate(string text)
        {
            return _transliterator.Transliterate(text);
        }
    }
}
