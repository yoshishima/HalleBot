using Microsoft.Bot.Connector;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Application1
{
    static class Intents
    {
        static readonly string luisUrl = "https://api.projectoxford.ai/luis/v1/application?id=b9855c51-eff1-49ff-9e8c-0be6f7e40da4&subscription-key=35a0ce06c71d483eb79c4caa55f4aaf0&q=";

        public static List<Intent> GetIntents(Message message)
        {
            string url = luisUrl + message.Text;
            WebRequest request = WebRequest.Create(url);
            using (var reader = new StreamReader(request.GetResponse().GetResponseStream()))
            {
                string result = reader.ReadToEnd();

                JObject data = JObject.Parse(result);
                var intents = data["intents"];
                return intents.Select(x =>
                {
                    return new Intent
                    {
                        intent = x["intent"].ToString(),
                        score = Convert.ToDouble(x["score"].ToString())
                    };
                }).ToList();
            }
        }
    }
}
