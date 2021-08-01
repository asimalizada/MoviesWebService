using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]  // www.k201.com/api/movies/getall
    [ApiController] 
    public class MoviesController : ControllerBase
    {
        private IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost("add")]
        public IActionResult Add(Movie movie) // www.k201.com/api/movies/add
        {
            var result = this._movieService.Add(movie);

            if (result.Success)
            {
                return Ok(result.Message);  // 200
            }

            return BadRequest(result.Message); // 400
        }

        [HttpPost("update")]
        public IActionResult Update(Movie movie) 
        {
            var result = this._movieService.Update(movie);

            if (result.Success)
            {
                return Ok(result.Message);  // 200
            }

            return BadRequest(result.Message); // 400
        }

        [HttpPost("delete")]
        public IActionResult Delete(Movie movie)
        {
            var result = this._movieService.Delete(movie);

            if (result.Success)
            {
                return Ok(result.Message);  // 200
            }

            return BadRequest(result.Message); // 400
        }

        [HttpGet("getall")]
        public IActionResult GetAll() // www.k201.com/api/movies/getall
        {
            var result = this._movieService.GetAll();

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getgenres")]
        public IActionResult GetByGenreId(int genreId) // ../api/movies/getgenres?genreId=1
        {
            var result = this._movieService.GetByGenreId(genreId);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

    }
}
