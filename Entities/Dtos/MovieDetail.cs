using Core.Entities.Abstract;

namespace Entities.Dtos
{
    public class MovieDetail : IDto
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public decimal Imdb { get; set; }
        public string GenreName { get; set; }
    }
}