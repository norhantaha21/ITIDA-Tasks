using Asp.Versioning;
using CinemaTicketBooking.Dtos.MovieDtos;
using CinemaTicketBooking.Models.Filter;
using CinemaTicketBooking.Models.Pagination;
using CinemaTicketBooking.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketBooking.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<MovieV1Dto>>> GetAll([FromQuery] MovieFilter filter)
        {
            var result = await _movieService.GetAllMoviesV1Async(filter);
            return Ok(result);
        }

    }
}
