using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Madals
{
    public class user
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string role { get; set; }
        public DateTime joindate { get; set; }
        public DateTime dob { get; set; }
        public DateTime cdate { get; set; }
        public string remarks { get; set; }

    }
}
