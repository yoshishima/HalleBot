using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Reflection;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Connector.Utilities;
using Newtonsoft.Json;
using Bot_Application1.DataAccess;
using System.Collections.Generic;
using System.Text;

namespace Bot_Application1
{
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<Message> Post([FromBody]Message message)
        {
            if (message.Type == "Message")
            {
                if (Greeting.IsGreeting(message.Text))
                    return message.CreateReplyMessage(Greeting.GetGreeting(message.From.Name));

                var intents = Intents.GetIntents(message);

                patient p = GetPatient(message);
                // record - returns the last 4 interactions
                List<interaction> actions = AddInteraction(message, intents[0], p.patientID)
                    .OrderByDescending(x => x.createDate).ToList();
                List<double> sentiments = actions.Select(x => {
                    double result = 0;
                    if (x.sentiment.HasValue)
                    {
                        double.TryParse(x.sentiment.ToString(), out result);
                    }
                    return result;
                }).ToList();

                return message.CreateReplyMessage(Response.GetResponseText(intents,
                    CalculateWeightedSentiment(sentiments), sentiments.Count, p.patientID));
            }
            else
            {
                return HandleSystemMessage(message);
            }
        }

        interaction CreateInteraction(Intent intent, double sentimentScore, string text)
        {
            interaction iaction = new interaction();
            interactionIntent iactionitem = new interactionIntent();
            iactionitem.confidence = intent.score;
            iactionitem.name = intent.intent;
            iaction.interactionIntents.Add(iactionitem);
            iaction.text = text;
            iaction.sentiment = Convert.ToDecimal(sentimentScore);
            return iaction;
        }

        patient GetPatient(Message message)
        {
            using (HalleBotDataContext db = new HalleBotDataContext())
            {
                if (message.From == null)
                {
                    message.From = new ChannelAccount();
                }

                if (message.From.Id == null)
                {
                    message.From.Id = "1000";
                }

                patient p = db.getPatient(message.From.Id);
                if (p == null)
                {
                    p = new patient
                    {
                        patientID = message.From.Id,
                        name = message.From.Name
                    };
                    db.addPatient(p);
                }

                return p;
            }
        }

        List<interaction> AddInteraction(Message message, Intent intent, string patientId)
        {
            using (HalleBotDataContext db = new HalleBotDataContext())
            {
                return db.addInteraction(patientId, CreateInteraction(intent, Sentiment.GetScore(message), message.Text));
            }
        }

        double CalculateWeightedSentiment(List<double> sentiments)
        {
            switch (sentiments.Count)
            {
                case 2:
                    return (sentiments[0] * 0.6) + (sentiments[1] * 0.4);
                case 3:
                    return (sentiments[0] * 0.5) + (sentiments[1] * 0.3) + (sentiments[2] * 0.2);
                case 4:
                    return (sentiments[0] * 0.4) + (sentiments[1] * 0.3) + (sentiments[2] * 0.2) + (sentiments[3] * 0.1);
                default:
                    return sentiments[0];
            }
        }

        private Message HandleSystemMessage(Message message)
        {
            if (message.Type == "Ping")
            {
                Message reply = message.CreateReplyMessage();
                reply.Type = "Ping";
                return reply;
            }
            else if (message.Type == "DeleteUserData")
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == "BotAddedToConversation")
            {
            }
            else if (message.Type == "BotRemovedFromConversation")
            {
            }
            else if (message.Type == "UserAddedToConversation")
            {
            }
            else if (message.Type == "UserRemovedFromConversation")
            {
            }
            else if (message.Type == "EndOfConversation")
            {
            }

            return null;
        }
    }
}