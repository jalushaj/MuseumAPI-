using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuseumAPI.Data;
using Projekti.Models;

namespace Projekti.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WorkController( AppDbContext context)
        {
            _context = context;
        }

        // GET: api/works
        [HttpGet]
        public async Task<ActionResult<IEnumerable<workModel>>> GetWorks()
        {
            var works = await _context.Work
                .Select(work => new workModel
                {
                    Id = work.Id,
                    Name = work.Name,
                    Artist = work.Artist,
                    Description = work.Description,
                    Category = work.Category,
                    CreationDate = work.CreationDate,
                    // If CreationDate is not null, format it as 'yyyy-MM-dd', otherwise return null
                    CreationDateText = work.CreationDateText ?? "No Date Available", // If no CreationDateText, return "No Date Available"
                    Era = work.Era
                })
                .ToListAsync();

            return Ok(works);
        }



        // GET: api/works/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<workModel>> GetWork(int id)
        {
            var work = await _context.Work.FindAsync(id);
            if (work == null)
            {
                return NotFound(new { Message = $"Work with ID {id} not found." });
            }

            return Ok(work);
        }

        // POST: api/works
        [HttpPost]
        public async Task<ActionResult<workModel>> CreateWork(workModel work)
        {
            // Validate the work object
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Ensure the ID is not manually set
            work.Id = 0;

            // Add the new work to the database
            _context.Work.Add(work);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                // Log the exception or handle it
                return StatusCode(500, new { Message = "An error occurred while saving the work.", Error = e.Message });
            }

            // Return the created work with a location header
            return CreatedAtAction(nameof(GetWork), new { id = work.Id }, work);
        }


        // PUT: api/works/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWork(int id, workModel updatedWork)
        {
            if (id != updatedWork.Id)
            {
                return BadRequest(new { Message = "ID mismatch." });
            }

            var existingWork = await _context.Work.FindAsync(id);
            if (existingWork == null)
            {
                return NotFound(new { Message = $"Work with ID {id} not found." });
            }

            // Update the existing work with the new values
            existingWork.Name = updatedWork.Name;
            existingWork.Artist = updatedWork.Artist;
            existingWork.Description = updatedWork.Description;
            existingWork.Category = updatedWork.Category;
            existingWork.CreationDate = updatedWork.CreationDate;
            existingWork.CreationDateText = updatedWork.CreationDateText;
            existingWork.Era = updatedWork.Era;

            // Mark the entity as modified and save changes
            _context.Entry(existingWork).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE: api/works/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWork(int id)
        {
            var work = await _context.Work.FindAsync(id);
            if (work == null)
            {
                return NotFound(new { Message = $"Work with ID {id} not found." });
            }

            // Remove the work from the database
            _context.Work.Remove(work);
            await _context.SaveChangesAsync();

            return Ok(new { Message = $"Work with ID {id} deleted successfully." });
        }
    }
}