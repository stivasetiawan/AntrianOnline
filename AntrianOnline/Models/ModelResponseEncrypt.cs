using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntrianOnline.AntrianOnline.Models
{
    public class MetaData
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
    public class ResponseEncrypt
    {
        [JsonProperty("metaData")]
        public MetaData MetaData { get; set; }
        [JsonProperty("response")]
        public string Response { get; set; }
    }
}
