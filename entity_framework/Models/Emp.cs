using System.ComponentModel.DataAnnotations;

namespace entity_framework.Models
{
    public class Emp
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set;}
        public string? city { get; set;}
        public int age { get; set;}
        public int price { get; set;}
    }
}
