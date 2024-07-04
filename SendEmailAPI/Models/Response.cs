using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendEmailAPI.Models
{
    public class Response
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }

        [JsonProperty("error")]
        public object Error { get; set; }
    }
}