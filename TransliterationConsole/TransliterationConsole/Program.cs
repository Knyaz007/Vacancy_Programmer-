// TransliterationConsole/Program.cs
using System;
using TransliterationLib;

namespace TransliterationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide a string to transliterate.");
                return;
            }

            var transliterator = new Transliterator();
            string input = string.Join(' ', args);
            string output = transliterator.Transliterate(input);
            Console.WriteLine(output);
        }
    }
}
