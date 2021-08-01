using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMovieDal : EfEntityRepositoryBase<Movie, MovieContext>, IMovieDal
    {
        public List<MovieDetail> GetMovieDetails(Expression<Func<Movie, bool>> filter = null)
        {
            using (MovieContext context = new MovieContext())
            {
                var result = from m in filter == null
                        ? context.Movies
                        : context.Movies.Where(filter)
                    join g in context.Genres on m.GenreId equals g.GenreId
                    select new MovieDetail
                    {
                        MovieId = m.MovieId,
                        MovieName = m.MovieName,
                        Imdb = m.Imdb,
                        GenreName = g.GenreName
                    };

                return result.ToList();
            }
        }
    }
}