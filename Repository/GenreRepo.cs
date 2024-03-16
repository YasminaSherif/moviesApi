using movies.Dto;


namespace movies.Repository
{
    public class GenreRepo : IGenre
    {
        ApplicationContext db;
        //ask for a the db built in service
        public GenreRepo(ApplicationContext db)
        {

            this.db = db;

        }

        public Genre AddGenre(GenreDto g)
        {
            Genre genre = new Genre() {Name=g.Name };
           db.Genres.Add(genre);
            db.SaveChanges();
            return(genre);
        }

        public Genre DeleteGenre(int id)
        {
            var result = db.Genres.SingleOrDefault(g => g.Id == id);
            if(result!=null)
            {
                db.Genres.Remove(result);
                db.SaveChanges() ;
            }
            return result;
        }

        public Genre EditGenre(int id, GenreDto g) { 
            var result = db.Genres.SingleOrDefault(g=>g.Id == id);

            if (result is not null)
            {
                result.Name = g.Name;
                db.SaveChanges();

            }
            return(result);
        }

        public List<Genre> GetGenres()
        {
            List<Genre> result= new List<Genre>();
            result=db.Genres.ToList();
            return result;
        }
    }
}
