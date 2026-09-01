using Asp.Versioning;
using CinemaTicketBooking.Dtos.MovieDtos;
using CinemaTicketBooking.Models.Filter;
using CinemaTicketBooking.Models.Pagination;
using CinemaTicketBooking.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketBooking.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<MovieV2Dto>>> GetAll([FromQuery] MovieFilter filter)
        {
            var result = await _movieService.GetAllMoviesV2Async(filter);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MovieV2Dto>> GetById(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult<MovieV2Dto>> Create([FromBody] CreateUpdateMovieDto dto)
        {
            var createdMovie = await _movieService.CreateMovieAsync(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { version = "2.0", id = createdMovie.Id },
                createdMovie);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<MovieV2Dto>> Update(int id, [FromBody] CreateUpdateMovieDto dto)
        {
            var updatedMovie = await _movieService.UpdateMovieAsync(id, dto);
            return Ok(updatedMovie);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _movieService.DeleteMovieAsync(id);
            return NoContent();
        }
    }
}