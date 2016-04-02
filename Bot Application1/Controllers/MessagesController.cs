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
            List<interaction> actions = null;

            if (message.Type == "Message")
            {
                var intents = Intents.GetIntents(message);

                double sentimentScore = Sentiment.GetScore(message);

                // record - returns the last 4 interactions
                patient p = null;
                using (HalleBotDataContext db = new HalleBotDataContext())
                {
                    interaction iaction = new interaction();
                    interactionIntent iactionitem = new interactionIntent();
                    iactionitem.confidence = intents[0].score;
                    iactionitem.name = intents[0].intent;
                    iaction.interactionIntents.Add(iactionitem);
                    iaction.text = message.Text;


                    if(message.From == null)
                    {
                        message.From = new ChannelAccount();
                    }

                    if(message.From.Id == null)
                    {
                        message.From.Id = "1000";
                    }

                    p = db.getPatient(message.From.Id);

                    if (p == null)
                    {
                        p = new patient();
                        p.patientID = message.From.Id;
                        p.name = message.From.Name;
                        db.addPatient(p);
                    }

                    iaction.sentiment = Convert.ToDecimal(sentimentScore);

                    actions = db.addInteraction(p.patientID, iaction);
                }
                // conv id, message, intents, score

                actions = actions.OrderByDescending(x => x.createDate).ToList();

                int size = actions.Count();

                interaction interaction1 = null;
                interaction interaction2 = null;
                interaction interaction3 = null;
                interaction interaction4 = null;

                double Sentiment1 = 0;
                double Sentiment2 = 0;
                double Sentiment3 = 0;
                double Sentiment4 = 0;

                double weightedSentiment;

                if (size >= 1) {
                    interaction1 = actions.ElementAt(0);
                    if (interaction1.sentiment.HasValue)
                    {
                        Double.TryParse(interaction1.sentiment.ToString(), out Sentiment1);
                    }
                }

                if (size >= 2)
                {
                   
                    interaction2 = actions.ElementAt(1);

                    if (interaction2.sentiment.HasValue)
                    {
                        Double.TryParse(interaction2.sentiment.ToString(), out Sentiment2);
                    }
                }

                if (size >= 3)
                {
                    interaction3 = actions.ElementAt(2);

                    if(interaction3.sentiment.HasValue)
                    {
                        Double.TryParse(interaction3.sentiment.ToString(), out Sentiment3);
                    }
                }
                
                if(size >= 4)
                {
                    interaction4 = actions.ElementAt(3);

                    if (interaction4.sentiment.HasValue)
                    {
                        Double.TryParse(interaction4.sentiment.ToString(), out Sentiment3);
                    }
                }

                switch (size)
                {
                    case 2:
                        weightedSentiment = (Sentiment1 * 0.6) + (Sentiment2 * 0.4);
                        break;
                    case 3:
                        weightedSentiment = (Sentiment1 * 0.5) + (Sentiment2 * 0.3) + (Sentiment3 * 0.2);
                        break;
                    case 4:
                        weightedSentiment = (Sentiment1 * 0.4) + (Sentiment2 * 0.3) + (Sentiment3 * 0.2) + (Sentiment4 * 0.1);
                        break;
                    default:
                        weightedSentiment = Sentiment1;
                        break;
                }

                // go get approp response
                // return the response from your object

                if (Greeting.IsGreeting(message.Text))
                    return message.CreateReplyMessage(Greeting.GetGreeting(message.From.Name));

                return message.CreateReplyMessage(Response.GetResponseText(intents, weightedSentiment, size, p.patientID));
            }
            else
            {
                return HandleSystemMessage(message);
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