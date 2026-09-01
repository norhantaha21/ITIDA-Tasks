using CinemaTicketBooking.Dtos.ShowTimeDtos;
using CinemaTicketBooking.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShowTimesController : ControllerBase
    {
        private readonly IShowTimeService _showTimeService;

        public ShowTimesController(IShowTimeService showTimeService)
        {
            _showTimeService = showTimeService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ShowTimeResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var showTimes = await _showTimeService.GetAllAsync();
            return Ok(showTimes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ShowTimeResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var showTime = await _showTimeService.GetByIdAsync(id);
            return Ok(showTime);
        }

        [HttpGet("movie/{movieId}")]
        [ProducesResponseType(typeof(IEnumerable<ShowTimeResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByMovieId(int movieId)
        {
            var showTimes = await _showTimeService.GetByMovieIdAsync(movieId);
            return Ok(showTimes);
        }

        [HttpGet("auditorium/{auditoriumId}")]
        [ProducesResponseType(typeof(IEnumerable<ShowTimeResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByAuditoriumAndDate(int auditoriumId, [FromQuery] DateTime? date = null)
        {
            var showTimes = await _showTimeService.GetByAuditoriumAndDateAsync(auditoriumId, date);
            return Ok(showTimes);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShowTimeResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create([FromBody] CreateUpdateShowTimeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdShowTime = await _showTimeService.CreateShowTimeAsync(dto);
            return Ok(createdShowTime);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ShowTimeResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] CreateUpdateShowTimeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedShowTime = await _showTimeService.UpdateShowTimeAsync(id, dto);
            return Ok(updatedShowTime);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _showTimeService.DeleteShowTimeAsync(id);
            return NoContent();
        }
    }
}
