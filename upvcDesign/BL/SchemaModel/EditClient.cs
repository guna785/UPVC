using DAL.Madals;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.SchemaModel
{
    public class EditClient
    {
        public EditClient()
        {

        }
        public EditClient(client _clt)
        {
            this.name = _clt.name;
            this.pan = _clt.pan;
            this.phone = _clt.phone;
            this.gst = _clt.gst;
            this.address = _clt.address;
            this.email = _clt.email;            
        }
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
