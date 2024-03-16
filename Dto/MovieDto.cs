namespace movies.Dto
{
    public class MovieDto
    {
        [MaxLength(250)]
        public string Title { get; set; }
        [MaxLength(2250)]
        public string Description { get; set; }
        public double Rate { get; set; }
        public int year { get; set; }
        public byte GenreId { get; set; }
    }
}
