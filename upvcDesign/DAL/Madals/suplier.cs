using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Madals
{
    public class suplier
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public string name { get; set; }
        
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string gst { get; set; }
        public string pan { get; set; }
        public DateTime cdate { get; set; }
        public string status { get; set; }
    }
}
