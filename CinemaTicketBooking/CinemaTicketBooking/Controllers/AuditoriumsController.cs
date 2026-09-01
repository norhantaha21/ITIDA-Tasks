using CinemaTicketBooking.Dtos.AudiotoriumDtos;
using CinemaTicketBooking.Repository.Interface;
using CinemaTicketBooking.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditoriumsController : ControllerBase
    {
        private readonly IAuditoriumService _auditoriumService;

        public AuditoriumsController(IAuditoriumService auditoriumService)
        {
            _auditoriumService = auditoriumService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AuditoriumDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var auditoriums = await _auditoriumService.GetAllAuditoriumAsync();
            return Ok(auditoriums);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AuditoriumDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var auditorium = await _auditoriumService.GetAuditoriumByIdAsync(id);
            return Ok(auditorium);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AuditoriumDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateUpdateAuditoriumDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdAuditorium = await _auditoriumService.CreateAuditoriumAsync(dto);
            return Ok(createdAuditorium);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(AuditoriumDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] CreateUpdateAuditoriumDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedAuditorium = await _auditoriumService.UpdateAuditoriumAsync(id, dto);
            return Ok(updatedAuditorium);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _auditoriumService.DeleteAuditoriumAsync(id);
            return NoContent();
        }


    }
}
