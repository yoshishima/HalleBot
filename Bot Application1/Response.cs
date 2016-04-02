using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Application1
{
    static class Response
    {
        // TODO: where should the primitives for response come from???

        // TODO: actual type for intent
        static Dictionary<string, List<string>> responses = new Dictionary<string, List<string>> {
            { "ContinueConversation", new List<string> {
                "Really?",
                "That's very interesting...",
                "I'd like to hear more..."
            } },
            { "EmergencyResponse", new List<string> {
                "Would you like for me to call someone for you?"
            } }
        };

        public static string GetResponseText(List<Intent> intents, double sentimentScore, int count)
        {
            var mostLikelyIntent = intents.OrderByDescending(x => x.score).First().intent;
            if (responses.ContainsKey(mostLikelyIntent))
                return responses[mostLikelyIntent].First();

            return intents.OrderByDescending(x => x.score).First().intent +  " - " + sentimentScore.ToString() + " - " + count;
        }
    }
}
