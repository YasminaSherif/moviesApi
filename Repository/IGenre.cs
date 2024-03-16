using Microsoft.AspNetCore.Mvc;
using movies.Dto;
using movies.Models;

namespace movies.Repository
{
    public interface IGenre
    {
        List<Genre> GetGenres();
        Genre AddGenre(GenreDto name);
        public Genre EditGenre(int id, GenreDto genre);
        Genre DeleteGenre(int id);

    }
}
