using DAL.Madals;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.SchemaModel
{
    public class EditEmp
    {
        public EditEmp()
        {

        }
        public EditEmp(user _user)
        {
            name = _user.name;
            uname = _user.uname;
            email = _user.email;
            phone = _user.phone;
            role = _user.role;
            password = "";
            address = _user.address;
        }
        [JsonProperty("Name", Required = Required.Always)]
        public string name { get; set; }
        [JsonProperty("UserName", Required = Required.Always)]
        [ReadOnly(true)]
        public string uname { get; set; }
        [JsonProperty("Password")]
        public string password { get; set; }
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
