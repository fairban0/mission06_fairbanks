using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mission07_fairbanks.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }  // Matches the database primary key

        [Required]
        public string CategoryName { get; set; } // This must match the column in the database

        // Navigation property: One category can have many movies
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}

