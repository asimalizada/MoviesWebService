using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Abstract
{
    public interface IMovieDal : IEntityRepository<Movie>
    {
        List<MovieDetail> GetMovieDetails(Expression<Func<Movie, bool>> filter = null);
    }
}