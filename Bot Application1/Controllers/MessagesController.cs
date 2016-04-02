using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Connector.Utilities;
using Newtonsoft.Json;
using Bot_Application1.DataAccess;
using System.Collections.Generic;

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
                // parse sentiment
                // figure intents (luis)
                var intents = Intents.GetIntents(message);

                double sentimentScore = Sentiment.GetScore(message);

                // record - returns the last 4 interactions
                using (HalleBotDataContext db = new HalleBotDataContext())
                {
                    interaction iaction = new interaction();
                    interactionIntent iactionitem = new interactionIntent();
                    iactionitem.confidence = intents[0].score;
                    iactionitem.name = intents[0].intent;
                    iaction.interactionIntents.Add(iactionitem);
                    iaction.text = message.Text;

                    iaction.sentiment = Convert.ToDecimal(sentimentScore);

                    actions = db.addInteraction("1000", iaction);
                }
                // conv id, message, intents, score

                // go get approp response
                // return the response from your object

                // return our reply to the user
                return message.CreateReplyMessage(Response.GetResponseText(intents, sentimentScore, actions.Count()));
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