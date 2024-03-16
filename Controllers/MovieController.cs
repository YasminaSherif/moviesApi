using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using movies.Dto;
using movies.Repository;

namespace movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        IMovie repo;

        private List<string> _allowedExtentions = new List<string>()
        {
            ".jpg",
            ".png"
        };
        private int _allowedSize = 1024 * 1024;

        public MovieController(IMovie repo)
        {
            this.repo = repo;
        }

        [HttpGet("GetMovies")]
        public IActionResult GetMovies()
        {
            List<MovieWithGenreDto> result;

            try
            {
                result = repo.GetMovies();

            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
            return  Ok(result);
        }


        [HttpPost("AddMovie")]
        public IActionResult AddMovie([FromForm] CreateMovieDto movieDto)
        {
            if (!_allowedExtentions.Contains(Path.GetExtension(movieDto.Poster.FileName).ToLower()))
            {
                return BadRequest("only .png amd .jpg are allowed");
            }

            if (movieDto.Poster.Length > _allowedSize) {
                return BadRequest("size should be less than 1 mb");
            }

            Movie movie;
            try
            {
                movie = repo.AddMovie(movieDto);
            }catch(Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(movie);

        }


        [HttpPut("EditMovie")]
        public IActionResult EditMovie([FromQuery] int id, [FromBody] MovieDto movieDto)
        {
            Movie result;
            try
            {
               result = repo.EditMovie(id, movieDto);
            }catch(Exception e)
            {
                return NotFound(e.Message);
            }
           
            return Ok(result);
        }


        [HttpDelete("DeleteMovie")]
        public IActionResult DeleteMovie([FromQuery] int id)
        {
            Movie result;
            try
            {
               result = repo.DeleteMovie(id);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            
            return  Ok("Deleted");
        }


        [HttpGet("GetMovieById/{id}")]
        public IActionResult GetMovieById(int id) {
            MovieWithGenreDto result;
            try {
                result = repo.GetMovieById(id);
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetMoviesByGenreId/{id}")]
        public IActionResult GetMoviesByGenreId(int id)
        {
            List<MovieWithGenreDto> result;
            try
            {
                result = repo.GetMoviesByGenreId(id);
            }catch(Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(result);
        }


    }
}
