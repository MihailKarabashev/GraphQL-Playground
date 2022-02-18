using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphQL_Playground.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Country { get; set; }

        public string League { get; set; }

        public ICollection<Player> Players { get; set; } = new List<Player>();
    }
}
