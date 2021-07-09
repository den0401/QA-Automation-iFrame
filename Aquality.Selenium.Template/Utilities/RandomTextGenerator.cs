using System;
using System.Text;

namespace Aquality.Selenium.Template.Utilities
{
    public class RandomTextGenerator
    {
        private readonly Random _random;

        private const int AsciiUpperLettersQuantity = 26;
        private const int AsciiALetter = 65;

        public RandomTextGenerator()
            {
                _random = new Random();
            }

        public string GetRandomWord()
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < _random.Next(Configuration.Configuration.MinLettersInWord, Configuration.Configuration.MaxLettersInWord); i++)
            {
                builder.Append(Convert.ToChar(Convert.ToInt32(Math.Floor(AsciiUpperLettersQuantity * _random.NextDouble() + AsciiALetter))));
            }

            return builder.ToString().ToLower();
        }

        public string[] GetWordsArray()
        {
            string[] words = new string[_random.Next(Configuration.Configuration.MinWordsInSentence, Configuration.Configuration.MaxWordsInSentence)];            

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = GetRandomWord();
            }

            return words;
        }

        public string GetRandomSentence(int wordCount)
        {
            StringBuilder builder = new StringBuilder();

            string[] _words = GetWordsArray();

            for (int i = 0; i < wordCount; i++)
            {
                builder.Append(_words[_random.Next(_words.Length)]).Append(" ");
            }

            string sentence = builder.ToString().Trim() + ". ";

            sentence = char.ToUpper(sentence[0]) + sentence.Substring(1);

            builder = new StringBuilder();
            builder.Append(sentence);

            return builder.ToString();
        }
    }
}
