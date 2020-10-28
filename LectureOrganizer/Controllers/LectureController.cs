using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using LectureOrganizer.Data;
using LectureOrganizer.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LectureOrganizer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectureController : ControllerBase
    {
        private readonly LectureContext _context;

        public LectureController(LectureContext context)
        {
            _context = context;
        }

        // GET: api/Lecture
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Lecture>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Lecture>>> GetLectures()
        {
            return await _context.Lecture
                .Include(e => e.Uni)
                .ToListAsync();
        }

        // GET: api/Lecture/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Lecture), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<Lecture>> GetLecture(Guid id)
        {
            var lecture = await _context.Lecture
                .Include(e => e.Uni)
                .Include(e => e.LectureComments)
                .ThenInclude(e => e.User)
                .FirstOrDefaultAsync(x => x.LectureId == id);

            if (lecture == null)
            {
                return NotFound();
            }

            return lecture;
        }

        // PUT: api/Lecture/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> PutLecture(Guid id, Lecture lecture)
        {
            if (id != lecture.LectureId)
            {
                return BadRequest();
            }

            _context.Lecture.Update(lecture);
            _context.Entry(lecture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LectureExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // POST: api/Lecture
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [ProducesResponseType(typeof(Lecture), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<Lecture>> PostLecture(Lecture lecture)
        {
            lecture.LectureId = Guid.NewGuid();
            _context.Lecture.Add(lecture);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                if (LectureExists(lecture.LectureId))
                {
                    return Conflict();
                }
                throw exception;
            }

            return CreatedAtAction("GetLecture", new { id = lecture.LectureId }, lecture);
        }

        // DELETE: api/Lecture/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Lecture), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<Lecture>> DeleteLecture(Guid id)
        {
            var lecture = await _context.Lecture.FindAsync(id);
            if (lecture == null)
            {
                return NotFound();
            }

            _context.Lecture.Remove(lecture);
            await _context.SaveChangesAsync();

            return lecture;
        }

        private bool LectureExists(Guid id)
        {
            return _context.Lecture.Any(e => e.LectureId == id);
        }
    }
}
