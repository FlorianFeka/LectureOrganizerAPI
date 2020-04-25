using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class LecturesController : ControllerBase
    {
        private readonly LectureContext _context;

        public LecturesController(LectureContext context)
        {
            _context = context;
        }

        // GET: api/Lectures
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Lecture>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Lecture>>> GetLectures()
        {
            return await _context.Lectures
                .Include(e => e.LectureComments)
                .ThenInclude(e => e.User)
                .ToListAsync();
        }

        // GET: api/Lectures/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Lecture), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<Lecture>> GetLecture(int id)
        {
            var lecture = await _context.Lectures
                .Include(e => e.LectureComments)
                .ThenInclude(e => e.User)
                .FirstOrDefaultAsync(x => x.LectureId == id);

            if (lecture == null)
            {
                return NotFound();
            }

            return lecture;
        }

        // PUT: api/Lectures/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> PutLecture(int id, Lecture lecture)
        {
            if (id != lecture.LectureId)
            {
                return BadRequest();
            }

            _context.Lectures.Update(lecture);
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
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Lectures
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [ProducesResponseType(typeof(Lecture), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<Lecture>> PostLecture(Lecture lecture)
        {
            _context.Lectures.Add(lecture);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LectureExists(lecture.LectureId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLecture", new { id = lecture.LectureId }, lecture);
        }

        // DELETE: api/Lectures/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Lecture), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<Lecture>> DeleteLecture(Guid id)
        {
            var lecture = await _context.Lectures.FindAsync(id);
            if (lecture == null)
            {
                return NotFound();
            }

            _context.Lectures.Remove(lecture);
            await _context.SaveChangesAsync();

            return lecture;
        }

        private bool LectureExists(int id)
        {
            return _context.Lectures.Any(e => e.LectureId == id);
        }
    }
}
