using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.SchemaModel
{
    public class AddEmp
    {
        [JsonProperty("Name", Required = Required.Always)]
        public string name { get; set; }
        [JsonProperty("UserName", Required = Required.Always)]
        public string uname { get; set; }
        [JsonProperty("Password", Required = Required.Always)]
        public string password { get; set; }
        [EmailAddress]
        [JsonProperty("Email", Required = Required.Always)]
        public string email { get; set; }
        [JsonProperty("Phone", Required = Required.Always)]
        [MaxLength(10)]
        public string phone { get; set; }
        [JsonProperty("Address", Required = Required.Always)]
        public string address { get; set; }
        [JsonProperty("Role", Required = Required.Always)]
        public string role { get; set; }
    }
}
