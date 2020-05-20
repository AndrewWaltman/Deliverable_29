using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deliverable_29.Models;
using Microsoft.AspNetCore.Mvc;

namespace Deliverable_29.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly MovieAPICreationDBContext _context = new MovieAPICreationDBContext();

        //Grabs the existing movies list
        [HttpGet]
        public ActionResult<MoviesApi> GetMovies()
        {
            //I was close with this before.
            //You have to create a new List with the database model, and create a new Context list.
            //the it is return Ok(variableName)
            List<MoviesApi> resultList = _context.MoviesApi.ToList();
            return Ok(resultList);
        }

        //Grabs the genre(category)
        [HttpGet]
        public ActionResult<MoviesApi> GetGenre(string genre)
        {
            List<MoviesApi> resultList = new List<MoviesApi>();
            var data = _context.MoviesApi.Where(x => x.MovieGenre == genre || x.MovieGenre == genre).ToList();
            foreach (MoviesApi movie in data)
            {
                resultList.Add(movie);
            }
            return Ok(resultList);
        }

        //Grabs a random Movie
        [HttpGet]
        public ActionResult<MoviesApi> GetRandMovie()
        {
            List<MoviesApi> data = _context.MoviesApi.ToList();
            Random rng = new Random();
            MoviesApi result = data[rng.Next(0, data.Count)];
            return Ok(result);
        }

        //Grabs a Random Category
        [HttpGet]
        public ActionResult<MoviesApi> GetRandomCategory(string randGenre)
        {
            List<MoviesApi> data = _context.MoviesApi.Where(x => x.MovieGenre == randGenre || x.MovieGenre == randGenre).ToList();
            Random rng = new Random();
            MoviesApi result = data[rng.Next(0, data.Count)];
            return Ok(result);
        }
    }
}
