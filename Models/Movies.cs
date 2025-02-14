using System.ComponentModel.DataAnnotations;

namespace mission06_fairbanks.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool? Edited { get; set; } // Nullable for optional fields

        public bool? Lent { get; set; } // Nullable for optional fields

        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}

