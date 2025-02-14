using System.ComponentModel.DataAnnotations;

namespace mission06_fairbanks.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class MovieViewModel
    {
        [Required(ErrorMessage = "Rating is required.")]
        public string Rating { get; set; }

        public bool? Edited { get; set; } // Nullable to allow optional selection

        public bool? Lent { get; set; } // Nullable to allow optional selection

        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string Notes { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        public string Year { get; set; }

        [Required(ErrorMessage = "Director is required.")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public string Category {  get; set; }
    }

}
