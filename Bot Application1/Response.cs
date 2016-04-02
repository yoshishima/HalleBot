using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Application1
{
    static class Response
    {
        static Dictionary<string, List<string>> responses = new Dictionary<string, List<string>> {
            { "ContinueConversation", new List<string> {
                "Really?",
                "That's very interesting...",
                "I'd like to hear more...",
                "How can I help?",
                "Hmmm... that`s interesting",
                "Can you expand on that for me?",
                "Please clarify",
                "Can you give me an example of a time you felt like this?",
                "Please, go on.",
                "You are doing good. Please continue?",
                "Where have you felt like this before?",
                "Why do you think you feel this way?",
                "Have you ever felt this way before?"
            } },
            { "EmergencyResponse", new List<string> {
                "Would you like for me to call someone for you?",
                "Would you like to be transferred to a live counselor?",
                "I can connect you to a trained mental health professional if you'd like.",
                "Would you like me to call your doctor?"
            } }
        };

        public static string GetResponseText(List<Intent> intents, double sentimentScore, int count, string patientID)
        {
            var mostLikelyIntent = intents.OrderByDescending(x => x.score).First().intent;
            if (responses.ContainsKey(mostLikelyIntent))
            {
                Random random = new Random();
                var possibleResponses = responses[mostLikelyIntent];
                return possibleResponses.ElementAt(random.Next(possibleResponses.Count));
            }   

            return intents.OrderByDescending(x => x.score).First().intent + " - " + sentimentScore.ToString() + " - " + count;

            //Intent i = intents.OrderByDescending(x => x.score).First();
            //if (i.intent == "ContinueConversation")
            //{
            //    using (DataAccess.HalleBotDataContext db = new DataAccess.HalleBotDataContext())
            //    {
            //        return db.getMessage(patientID, DataAccess.MessageTypeEnum.keepgoing).messageText;
            //    }
            //}
            //else
            //{
            //    return i.intent + " - " + sentimentScore.ToString() + " - " + count;
            //}
        }
    }
}
