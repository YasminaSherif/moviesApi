
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using movies.Dto;

namespace movies.Repository
{
    public class MovieRepo : IMovie
    {
        ApplicationContext db;
        public MovieRepo(ApplicationContext db)
        {

            this.db = db;

        }

        public Movie AddMovie(CreateMovieDto movieDto)
        {
            if (!db.Genres.Any(g => g.Id == movieDto.GenreId))
                throw new Exception("No genre was found");
            MemoryStream dataStream = new MemoryStream();
            movieDto.Poster.CopyTo(dataStream);
            Movie movie = new Movie()
            {
                Title = movieDto.Title,
                Description = movieDto.Description,
                GenreId = movieDto.GenreId,
                Rate= movieDto.Rate,
                Poster=dataStream.ToArray(),
                year=movieDto.year
            };

            db.Movies.Add(movie);
            db.SaveChanges();
            return movie;
        }

        public Movie DeleteMovie(int id)
        {
            var movie = db.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                throw new Exception("No movie was found"); 
            db.Movies.Remove(movie);
            db.SaveChanges();
            return movie;
        }

        public Movie EditMovie(int id, MovieDto movieDto)
        {
          var movie = db.Movies.SingleOrDefault(m=>m.Id==id);

            if (movie == null)
                throw new Exception("movie wasn't found");

                movie.Title = movieDto.Title;
                movie.Description = movieDto.Description;
                movie.GenreId = movieDto.GenreId;
                movie.Rate = movieDto.Rate;
            db.SaveChanges();

            return movie;
        }

        public List<MovieWithGenreDto> GetMovies()
        {
            
           List<MovieWithGenreDto> result = db.Movies.Include(m => m.Genre).Select(m => new MovieWithGenreDto()
            {
                Description = m.Description,
                GenreId = m.GenreId,
                genreName = m.Genre.Name,
                poster = m.Poster,
                Rate=m.Rate,
                Title=m.Title,
                year=m.year
            }).ToList();

            if (result.Count == 0)
                throw new Exception("no movies were added yet");

            return result;
        }

        public MovieWithGenreDto GetMovieById(int id)
        {
            var movie = db.Movies.Include(m=>m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie is null)
                throw new Exception("no movie was found with this id");

            return new MovieWithGenreDto {
               
                Description = movie.Description,
                GenreId = movie.GenreId,
                genreName = movie.Genre.Name,
                poster = movie.Poster,
                Rate = movie.Rate,
                Title = movie.Title,
                year = movie.year
            };
        }

        public List<MovieWithGenreDto> GetMoviesByGenreId(int id)
        {
            if (db.Genres.SingleOrDefault(g => g.Id == id) is null)
            {
                throw new Exception("No Genre found with this id");
            }

            var movies = db.Movies.Where(m => m.GenreId == id).ToList();

            if (movies.Count==0) {
                throw new Exception("No Mocies in this genre were found");
            }

            List<MovieWithGenreDto> result = new List<MovieWithGenreDto>();
            foreach (var movie in movies)
            {
               result.Add(new MovieWithGenreDto
                {

                    Description = movie.Description,
                    GenreId = movie.GenreId,
                    genreName = movie.Genre.Name,
                    poster = movie.Poster,
                    Rate = movie.Rate,
                    Title = movie.Title,
                    year = movie.year
                });
            }
            return result;
        }
    }
}
