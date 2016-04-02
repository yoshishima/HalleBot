using System;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using System.Web;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bot_Application1
{

    public static class Sentiment
    {

        public static double GetScore(Message message)
        {

            HttpClient client = new HttpClient();

            // Request headers
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Ocp-Apim-Subscription-Key", "285b092897e74de7b2141f37c6c7852b");

            var uri = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/sentiment";

            HttpResponseMessage response;

            var docs = new SentimentRequest
            {
                Documents = new List<SentimentItem>
                {
                    new SentimentItem {id = "myid", text = message.Text},
                }
            };

            //Using Newtonsoft.json. Dump is an extension method of [Linqpad][4]
            var body = JsonConvert.SerializeObject(docs);

            byte[] byteData = Encoding.UTF8.GetBytes(body);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                response = client.PostAsync(uri, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;

                    JObject data = JObject.Parse(result);

                    var scores = data["documents"];

                    return Double.Parse(scores[0]["score"].ToString());

                }
                else
                {
                    return 50.0;
                }

            }

        }
    }
}