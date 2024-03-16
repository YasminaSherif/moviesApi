
using System.ComponentModel.DataAnnotations.Schema;

namespace movies.Models
{
    public class Genre
    {      
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        [MaxLength(10)]
        public string Name { get; set; }

        List<Movie> Movies { get; set;} = new List<Movie>();
    }
}
