using DAL.Madals;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.SchemaModel
{
    public class EditSuplier
    {
        public EditSuplier()
        {

        }
        public EditSuplier(suplier _sup)
        {
            this.name = _sup.name;
            this.pan = _sup.pan;
            this.phone = _sup.phone;
            this.gst = _sup.gst;
            this.address = _sup.address;
            this.email = _sup.email;
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
