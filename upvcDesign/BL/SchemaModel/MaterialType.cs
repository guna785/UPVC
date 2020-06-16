using DAL.Madals;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.SchemaModel
{
    public class MaterialType
    {
             
        [JsonProperty("Name", Required = Required.Always)]
        public string name { get; set; }
    }
}
