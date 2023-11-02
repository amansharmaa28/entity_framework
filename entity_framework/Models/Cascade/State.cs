using System.ComponentModel.DataAnnotations;

namespace entity_framework.Models.Cascade
{
    public class State
    {
       
        public int Id { get; set; }

        public string Name { get; set; }

        public Country Country { get; set; }
    }

}

