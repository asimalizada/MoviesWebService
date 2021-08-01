using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IGenreService
    {
        void Add(Genre genre);
        void Update(Genre genre);
        void Delete(Genre genre);
        List<Genre> GetAll();
    }
}