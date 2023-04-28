using System.ComponentModel.DataAnnotations;

namespace Zapocet.Data.Dto
{
    public class EshopDto
    {
        public string poid { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string item { get; set; }
        public int amount { get; set; }
        public double price { get; set; }
        public string createdon { get; set; }
    }
}
