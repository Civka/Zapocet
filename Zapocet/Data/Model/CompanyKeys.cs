using System.ComponentModel.DataAnnotations;

namespace Zapocet.Data.Model
{
    public class CompanyKeys
    {
        [Key]
        public int Id { get; set; }
        public int CompanyKey { get; set; }
        public string CompanyHash { get; set; }

    }
}