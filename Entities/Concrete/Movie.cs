using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Movie : IEntity
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public decimal Imdb { get; set; }
        public int GenreId { get; set; }
    }
}