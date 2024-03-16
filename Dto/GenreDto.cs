namespace movies.Dto
{
    public class GenreDto
    {
        [MaxLength(10)]
        public string Name { get; set; }
    }
}
