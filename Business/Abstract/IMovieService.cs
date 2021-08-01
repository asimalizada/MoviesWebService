using System.Collections.Generic;
using Core.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IMovieService
    {
        IResult Add(Movie movie);
        IResult Update(Movie movie);
        IResult Delete(Movie movie);
        IDataResult<List<Movie>> GetAll();
        //IDataResult<List<Movie>> GetById(int id);
        //IDataResult<List<Movie>> GetByMovieName(string movieName);
        IDataResult<List<Movie>> GetByGenreId(int genreId);
        //IDataResult<decimal> GetMinImdb();
        //IDataResult<decimal> GetMaxImdb();
        //IDataResult<List<decimal>> GetImdbs();
        //IDataResult<List<Movie>> GetByImdb(decimal min, decimal max);
        //IDataResult<List<MovieDetail>> GetMovieDetails();
        //IDataResult<int> GetNextId();
    }
}