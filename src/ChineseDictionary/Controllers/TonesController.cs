using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChineseDictionary.Data;
using ChineseDictionary.Models.EntityModels;

namespace ChineseDictionary.Controllers
{
    [Produces("application/json")]
    [Route("api/Tones")]
    public class TonesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TonesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Tones
        [HttpGet]
        public IEnumerable<Tone> GetTones()
        {
            return _context.Tones;
        }

        // GET: api/Tones/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTone([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Tone tone = await _context.Tones.SingleOrDefaultAsync(m => m.Id == id);

            if (tone == null)
            {
                return NotFound();
            }

            return Ok(tone);
        }

        // PUT: api/Tones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTone([FromRoute] int id, [FromBody] Tone tone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tone.Id)
            {
                return BadRequest();
            }

            _context.Entry(tone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToneExists(id))
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

        // POST: api/Tones
        [HttpPost]
        public async Task<IActionResult> PostTone([FromBody] Tone tone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tones.Add(tone);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ToneExists(tone.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return CreatedAtAction("GetTone", new { id = tone.Id }, tone);
        }

        // DELETE: api/Tones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTone([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Tone tone = await _context.Tones.SingleOrDefaultAsync(m => m.Id == id);
            if (tone == null)
            {
                return NotFound();
            }

            _context.Tones.Remove(tone);
            await _context.SaveChangesAsync();

            return Ok(tone);
        }

        private bool ToneExists(int id)
        {
            return _context.Tones.Any(e => e.Id == id);
        }
    }
}