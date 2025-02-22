using mission07_fairbanks.Models;
using System.ComponentModel.DataAnnotations;

namespace mission07_fairbanks.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required]
        public int CategoryId { get; set; }  // Foreign key to Categories

        public Category? Category { get; set; }  // Navigation Property

        [Required]
        public string? Title { get; set; }

        [Required]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
        public int Year { get; set; }

        public string? Director { get; set; }

        [Required]
        public string Rating { get; set; } = string.Empty;

        public bool? Edited { get; set; }

        public string? LentTo { get; set; }

        [Required]
        public bool CopiedToPlex { get; set; }


        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}




