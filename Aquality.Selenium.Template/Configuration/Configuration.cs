using System;

namespace Aquality.Selenium.Template.Configuration
{
    public static class Configuration
    {
        public static string StartUrl => Environment.CurrentEnvironment.GetValue<string>("url");
        public static int CountOfRandomWords => Convert.ToInt32(Environment.CurrentEnvironment.GetValue<string>("countOfRandomWords"));
        public static string PageTitle => Environment.CurrentEnvironment.GetValue<string>("pageTitle");
        public static int MinLettersInWord => Convert.ToInt32(Environment.CurrentEnvironment.GetValue<string>("minLettersNumberInWord"));
        public static int MaxLettersInWord => Convert.ToInt32(Environment.CurrentEnvironment.GetValue<string>("maxLettersNumberInWord"));
        public static int MinWordsInSentence => Convert.ToInt32(Environment.CurrentEnvironment.GetValue<string>("minWordsInSentence"));
        public static int MaxWordsInSentence => Convert.ToInt32(Environment.CurrentEnvironment.GetValue<string>("maxWordsInSentence"));
    }
}
