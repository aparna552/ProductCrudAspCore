using System;

namespace ProductManagement.Models
{
    public class Product
    {
        public int productid { get; set; }
        public string productname { get; set; }
        public string description { get; set; }

        public  DateTime createddate { get; set; }

       // public string response { get; set; }
    }
}
