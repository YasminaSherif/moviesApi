using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using movies.Dto;
using movies.Models;
using movies.Repository;
using System.Diagnostics.Metrics;

namespace movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        IGenre repo;

        // ask for a service
        //asking for any class thats implements IGenre and at the program 
        //the service will send the spacific type
        public GenreController(IGenre repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            return Ok(repo.GetGenres());
        }

        //[JsonIgnore] makes json ignore this data in serialization better seloution is DTO data transfeer object
        [HttpPost]
        [Route("addGenre")] //if this / came first it means override the initial route
        public IActionResult CreateGenre(GenreDto Name)
         {
            return Ok(repo.AddGenre(Name));

        }
        [HttpPut("EditGenre/{id}")]

        public IActionResult EditGenre(int id,[FromBody] GenreDto g)
        {
            var result=repo.EditGenre(id, g);
            
          return result is not null ?  Ok(result) : NotFound();
        }
        [HttpDelete("DeleteGenre/{id}")]
        public IActionResult DeleteGenre(int id)
        {
          var result= repo.DeleteGenre(id);
            return result is not null ? Ok() : NotFound("Genre was not found.");
        }


    }
}
