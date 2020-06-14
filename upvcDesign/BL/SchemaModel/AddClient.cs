using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.SchemaModel
{
    public class AddClient
    {
        [JsonProperty("Name", Required = Required.Always)]
        public string name { get; set; }
        [JsonProperty("Email", Required = Required.Always)]
        public string email { get; set; }
        [JsonProperty("Phone", Required = Required.Always)]
        public string phone { get; set; }
        [JsonProperty("Address", Required = Required.Always)]
        public string address { get; set; }
        [JsonProperty("GST", Required = Required.Always)]
        public string gst { get; set; }
        [JsonProperty("PAN", Required = Required.Always)]
        public string pan { get; set; }
    }
}
