using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot_Application1
{
    public static class Greeting
    {
        static List<string> greetingKeys = new List<string> { "hi", "hello", "howdy", "halle" };

        static List<string> greetings = new List<string> {
            "Hi {0}! How are you today?",
            "Top o' the morning to you {0}!",
            "I'm really happy to hear from you {0} :)"
        };

        public static bool IsGreeting(string message)
        {
            string messageText = message.ToLower();
            return greetingKeys.Where(x => messageText.Contains(x)).Any();
        }

        public static string GetGreeting(string to)
        {
            Random random = new Random();
            return string.Format(greetings[random.Next(greetings.Count)], to.Replace("8:", ""));
        }
    }
}