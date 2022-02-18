using System.ComponentModel.DataAnnotations;

namespace GraphQL_Playground.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Nationality { get; set; }

        public string Position { get; set; }

        public Team Team { get; set; }

        [Required]
        public int TeamId { get; set; }
    }
}
