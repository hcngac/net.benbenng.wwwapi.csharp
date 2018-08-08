using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using net.benbenng.wwwapi;

namespace net.benbenng.wwwapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaggingsController : ControllerBase
    {
        private readonly SiteDbContext _context;

        public TaggingsController(SiteDbContext context)
        {
            _context = context;
        }

        // GET: api/Taggings
        [HttpGet]
        public IEnumerable<Tagging> GetTaggings()
        {
            return _context.Taggings;
        }

        // GET: api/Taggings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagging([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tagging = await _context.Taggings.FindAsync(id);

            if (tagging == null)
            {
                return NotFound();
            }

            return Ok(tagging);
        }

        // PUT: api/Taggings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTagging([FromRoute] int id, [FromBody] Tagging tagging)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tagging.TaggingId)
            {
                return BadRequest();
            }

            _context.Entry(tagging).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaggingExists(id))
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

        // POST: api/Taggings
        [HttpPost]
        public async Task<IActionResult> PostTagging([FromBody] Tagging tagging)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Taggings.Add(tagging);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTagging", new { id = tagging.TaggingId }, tagging);
        }

        // DELETE: api/Taggings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTagging([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tagging = await _context.Taggings.FindAsync(id);
            if (tagging == null)
            {
                return NotFound();
            }

            _context.Taggings.Remove(tagging);
            await _context.SaveChangesAsync();

            return Ok(tagging);
        }

        private bool TaggingExists(int id)
        {
            return _context.Taggings.Any(e => e.TaggingId == id);
        }
    }
}