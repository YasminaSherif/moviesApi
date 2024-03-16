namespace movies.Dto
{
    public class CreateMovieDto:MovieDto
    {
        public IFormFile Poster { get; set; }
    }
}
