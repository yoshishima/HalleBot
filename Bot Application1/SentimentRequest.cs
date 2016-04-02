using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot_Application1
{
    public class SentimentRequest
    {
        public List<SentimentItem> Documents { get; set; }
    }

    public class SentimentItem
    {
        public string id { get; set; }
        public string text { get; set; }
    }

}