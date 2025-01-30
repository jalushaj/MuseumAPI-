using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using MuseumAPI.Data.Services;

namespace tryfour.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExhibitionsController : ControllerBase
    {
        private readonly ExhibitionService _service;

        public ExhibitionsController(ExhibitionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var exhibitions = await _service.GetAllAsync();
            return Ok(exhibitions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var exhibition = await _service.GetByIdAsync(id);
            if (exhibition == null) return NotFound();
            return Ok(exhibition);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ExhibitionDTO exhibitionDTO)
        {
            await _service.AddAsync(exhibitionDTO);
            return CreatedAtAction(nameof(GetById), new { id = exhibitionDTO.Name }, exhibitionDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ExhibitionDTO exhibitionDTO)
        {
            await _service.UpdateAsync(id, exhibitionDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
