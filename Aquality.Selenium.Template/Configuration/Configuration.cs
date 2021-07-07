using System;

namespace Aquality.Selenium.Template.Configuration
{
    public static class Configuration
    {
        public static string StartUrl => Environment.CurrentEnvironment.GetValue<string>("url");
        public static int CountOfRandomWords => Convert.ToInt32(Environment.CurrentEnvironment.GetValue<string>("countOfRandomWords"));
    }
}
