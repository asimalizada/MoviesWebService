using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Genre : IEntity
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }
}
