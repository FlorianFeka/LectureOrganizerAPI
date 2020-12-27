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
    public class LectureCommentController : ControllerBase
    {
        private readonly LectureContext _context;

        public LectureCommentController(LectureContext context)
        {
            _context = context;
        }

        // GET: api/LectureComment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LectureComment>>> GetLectureComment()
        {
            return await _context.LectureComment.ToListAsync();
        }

        // GET: api/LectureComment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LectureComment>> GetLectureComment(Guid id)
        {
            var lectureComment = await _context.LectureComment.FindAsync(id);

            if (lectureComment == null)
            {
                return NotFound();
            }

            return lectureComment;
        }

        // PUT: api/LectureComment/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLectureComment(Guid id, LectureComment lectureComment)
        {
            if (id != lectureComment.LectureCommentId)
            {
                return BadRequest();
            }

            _context.Entry(lectureComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LectureCommentExists(id))
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

        // POST: api/LectureComment
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LectureComment>> PostLectureComment(LectureComment lectureComment)
        {
            _context.LectureComment.Add(lectureComment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LectureCommentExists(lectureComment.LectureCommentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLectureComment", new { id = lectureComment.LectureCommentId }, lectureComment);
        }

        // DELETE: api/LectureComment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LectureComment>> DeleteLectureComment(Guid id)
        {
            var lectureComment = await _context.LectureComment.FindAsync(id);
            if (lectureComment == null)
            {
                return NotFound();
            }

            _context.LectureComment.Remove(lectureComment);
            await _context.SaveChangesAsync();

            return lectureComment;
        }

        private bool LectureCommentExists(Guid id)
        {
            return _context.LectureComment.Any(e => e.LectureCommentId == id);
        }
    }
}
