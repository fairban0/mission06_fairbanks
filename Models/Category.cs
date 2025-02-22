using System.ComponentModel.DataAnnotations;

namespace mission07_fairbanks.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }  // Primary key

        public string CategoryName { get; set; }  // This is what will be displayed

        // Navigation property: One category can have many movies
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}

