
using DAL.Madals;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BL.SchemaModel
{
    public class CompanyProfile
    {
        public CompanyProfile() { }
        public CompanyProfile(companyprofile _company)
        {
            this.accountno = _company.accountno;
            this.address = _company.address;
            this.bankname = _company.bankname;
            this.branch = _company.branch;
            this.email = _company.email;
            this.gst = _company.gst;
            this.ifsccode = _company.ifsccode;
            this.name = _company.name;
            this.pan = _company.pan;
            this.phone = _company.phone;
        }

        [JsonProperty("Name", Required = Required.Always)]
        public string name { get; set; }
        [JsonProperty("EMail", Required = Required.Always)]
        public string email { get; set; }
        [JsonProperty("Phone", Required = Required.Always)]
        public string phone { get; set; }
        [JsonProperty("Address", Required = Required.Always)]
        public string address { get; set; }
        [JsonProperty("PAN", Required = Required.Always)]
        public string pan { get; set; }
        [JsonProperty("GST", Required = Required.Always)]
        public string gst { get; set; }
        [JsonProperty("AccountNo", Required = Required.Always)]
        public string accountno { get; set; }
        [JsonProperty("BankName", Required = Required.Always)]
        public string bankname { get; set; }
        [JsonProperty("IFSCCode", Required = Required.Always)]
        public string ifsccode { get; set; }
        [JsonProperty("Brach", Required = Required.Always)]
        public string branch { get; set; }
    }
}
