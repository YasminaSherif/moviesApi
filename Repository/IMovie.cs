using movies.Dto;

namespace movies.Repository
{
    public interface IMovie
    {
        List<MovieWithGenreDto> GetMovies();
        Movie AddMovie(CreateMovieDto movieDto);
        Movie EditMovie(int id, MovieDto movieDto);
        Movie DeleteMovie(int id);
        public MovieWithGenreDto GetMovieById(int id);
        public List<MovieWithGenreDto> GetMoviesByGenreId(int id);
    }
}
