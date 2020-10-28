using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LectureOrganizer.Data;
using LectureOrganizer.Models;

namespace LectureOrganizer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniController : ControllerBase
    {
        private readonly LectureContext _context;

        public UniController(LectureContext context)
        {
            _context = context;
        }

        // GET: api/Uni
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Uni>>> GetUni()
        {
            return await _context.Uni.ToListAsync();
        }

        // GET: api/Uni/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Uni>> GetUni(Guid id)
        {
            var uni = await _context.Uni.FindAsync(id);

            if (uni == null)
            {
                return NotFound();
            }

            return uni;
        }

        // PUT: api/Uni/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUni(Guid id, Uni uni)
        {
            if (id != uni.UniId)
            {
                return BadRequest();
            }

            _context.Entry(uni).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UniExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Uni
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Uni>> PostUni(Uni uni)
        {
            _context.Uni.Add(uni);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UniExists(uni.UniId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUni", new { id = uni.UniId }, uni);
        }

        // DELETE: api/Uni/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Uni>> DeleteUni(Guid id)
        {
            var uni = await _context.Uni.FindAsync(id);
            if (uni == null)
            {
                return NotFound();
            }

            _context.Uni.Remove(uni);
            await _context.SaveChangesAsync();

            return uni;
        }

        private bool UniExists(Guid id)
        {
            return _context.Uni.Any(e => e.UniId == id);
        }
    }
}
