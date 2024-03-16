namespace movies.Dto
{
    public class MovieWithGenreDto:MovieDto
    {
        public string genreName { get; set; }
        public Byte[] poster { get; set;}
    }
}
