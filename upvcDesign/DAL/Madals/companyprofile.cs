using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Madals
{
     public class companyprofile
     {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int ID { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string pan { get; set; }
        public string gst { get; set; }
        public string accountno { get; set; }
        public string bankname { get; set; }
        public string ifsccode { get; set; }
        public string branch { get; set; }
        public DateTime cdate { get; set; }
        public string remarks { get; set; }

     }
}
