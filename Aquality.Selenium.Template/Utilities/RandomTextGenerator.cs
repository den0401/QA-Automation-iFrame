using System;
using System.Text;

namespace Aquality.Selenium.Template.Utilities
{
    public class RandomTextGenerator
    {
        private readonly Random _random;

        private const int _asciiUpperLettersQuantity = 26;
        private const int _asciiALetter = 65;
        private readonly string[] words = { "an", "automobile", "or", "motor", "car", "is", "a", "wheeled", "motor", "vehicle", "used", "for", "transporting", "passengers", "which", "also", "carries", "its", "own", "engine", "or" };

        public RandomTextGenerator()
            {
                _random = new Random();
            }

        public string GetRandomTextUpper(int size)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < size; i++)
            {
                builder.Append(Convert.ToChar(Convert.ToInt32(Math.Floor(_asciiUpperLettersQuantity * _random.NextDouble() + _asciiALetter))));
            }

            return builder.ToString();
        }

        public string GetRandomTextLower(int size)
        {
            return this.GetRandomTextUpper(size).ToLower();
        }

        public string GetRandomSentence(int wordCount)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < wordCount; i++)
            {
                builder.Append(words[_random.Next(words.Length)]).Append(" ");
            }

            string sentence = builder.ToString().Trim() + ". ";

            sentence = char.ToUpper(sentence[0]) + sentence.Substring(1);

            builder = new StringBuilder();
            builder.Append(sentence);

            return builder.ToString();
        }
    }
}
