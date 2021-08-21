using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Business.CrossCuttingConcerns.Validation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete  
{
    public class MovieManager : IMovieService
    {
        private readonly IMovieDal _movieDal;

        public MovieManager(IMovieDal movieDal)
        {
            _movieDal = movieDal;
        }

        [ValidationAspect(typeof(MovieValidator))]
        [CacheRemoveAspect("Get")]
        //[AutorizationAspect("moderator,admin")]
        public IResult Add(Movie movie)
        {
            //...
            if ((DateTime.Now.Hour == 23 & DateTime.Now.Minute == 59) 
                & (DateTime.Now.Hour == 7 & DateTime.Now.Minute == 59))
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }

            //ValidatorTool.Validate(movie, new MovieValidator());
            //ValidatorTool.ValidateGeneric(movie, new MovieValidator());
            //... 
            _movieDal.Add(movie);

            return new SuccessResult(Messages.AddMovie);
        }

        [ValidationAspect(typeof(MovieValidator))]
        [CacheRemoveAspect("Get")]
        public IResult Update(Movie movie)
        {
            _movieDal.Update(movie);

            return new SuccessResult();
        }

        [CacheRemoveAspect("Get")]
        public IResult Delete(Movie movie)
        {
            _movieDal.Delete(movie);
            return new SuccessResult();
        }

        [CacheAspect]
        [PerformanceAspect(0)]
        public IDataResult<List<Movie>> GetAll()
        {
            if ((DateTime.Now.Hour == 23 & DateTime.Now.Minute == 59)
                & (DateTime.Now.Hour == 7 & DateTime.Now.Minute == 59))
            {
                return new ErrorDataResult<List<Movie>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Movie>>(_movieDal.GetAll());
        }

        [CacheAspect]
        public List<Movie> GetById(int id)
        {
            return _movieDal.GetAll(m => m.MovieId == id);
        }

        [CacheAspect]
        public List<Movie> GetByMovieName(string movieName)
        {
            return _movieDal.GetAll(m => m.MovieName
                .ToLower().Contains(movieName.ToLower()));
        }

        [CacheAspect]
        public IDataResult<List<Movie>> GetByGenreId(int genreId)
        {
            return new SuccessDataResult<List<Movie>>(_movieDal.GetAll(m => m.GenreId == genreId));
        }

        //public List<decimal> GetImdbs()
        //{
        //    return this.GetAll().Select(m => m.Imdb).ToList();
        //}

        //public List<Movie> GetByImdb(decimal min, decimal max)
        //{
        //    return this._movieDal
        //        .GetAll(m => m.Imdb >= min & m.Imdb <= max);
        //}

        //public List<MovieDetail> GetMovieDetails()
        //{
        //    return this._movieDal.GetMovieDetails();
        //}

        //public int GetNextId()
        //{
        //    return this._movieDal.GetNextId();
        //}

        //public decimal GetMinImdb()
        //{
        //    return this.GetImdbs().Min();
        //}

        //public decimal GetMaxImdb()
        //{
        //    return GetImdbs().Max();
        //}
    }
}