using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mission07_fairbanks.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Categories Category { get; set; }

        [Required]

        private string _title;
        public string Title { get => _title; set => _title = value?.ToLower();}

        [Required]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
        public int Year { get; set; }


        private string _director;

        public string Director
        {
            get => _director; set => _director = value?.ToLower(); // Nullable
        }

        [Required]
        public string Rating { get; set; }

        public bool? Edited { get; set; } // Nullable for optional fields

        public bool? LentTo { get; set; } // Nullable for optional fields

        [Required]
        public bool? CopiedToPlex { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}

