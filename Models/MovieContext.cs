using Microsoft.EntityFrameworkCore;

namespace mission07_fairbanks.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }  // Required for the join
    }


}


