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

        public static string GetResponseText(List<Intent> intents, double sentimentScore, int count, string patientID)
        {
            //return "No matter where you go, there you are...";
            Intent i = intents.OrderByDescending(x => x.score).First();
            if (i.intent == "ContinueConversation")
            {
                using (DataAccess.HalleBotDataContext db = new DataAccess.HalleBotDataContext())
                {
                    return db.getMessage(patientID, DataAccess.MessageTypeEnum.keepgoing).messageText;
                }
            }
            else
            {
                return i.intent + " - " + sentimentScore.ToString() + " - " + count;
            }
        }
    }
}
