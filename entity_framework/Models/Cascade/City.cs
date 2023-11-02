using System.ComponentModel.DataAnnotations;

namespace entity_framework.Models.Cascade
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public State State { get; set; }
    }

}

