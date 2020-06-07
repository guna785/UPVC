using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DAL.Madals
{
    public class admin
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        public string name { get; set; }
        [Required(ErrorMessage ="UserName can not be Null")]
        public string uname { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string role { get; set; }
        public DateTime cdate { get; set; }
        public string remarks { get; set; }

    }
}
