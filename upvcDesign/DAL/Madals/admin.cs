using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Madals
{
    public class admin
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int ID { get; set; }
        public string name { get; set; }
        public string uname { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string role { get; set; }
        public string cdate { get; set; }
        public string remarks { get; set; }

    }
}
