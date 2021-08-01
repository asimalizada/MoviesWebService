using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class GenreManager : IGenreService
    {
        private IGenreDal _genreDal;

        public GenreManager(IGenreDal genreDal)
        {
            _genreDal = genreDal;
        }

        public void Add(Genre genre)
        {
            _genreDal.Add(genre);
        }

        public void Update(Genre genre)
        {
            _genreDal.Update(genre);
        }

        public void Delete(Genre genre)
        {
            _genreDal.Delete(genre);
        }

        public List<Genre> GetAll()
        {
            return _genreDal.GetAll();
        }
    }
}