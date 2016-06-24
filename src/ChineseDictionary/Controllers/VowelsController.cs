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
    [Route("api/Vowels")]
    public class VowelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VowelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Vowels
        [HttpGet]
        public IEnumerable<Vowel> GetVowels()
        {
            return _context.Vowels;
        }

        // GET: api/Vowels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVowel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Vowel vowel = await _context.Vowels.SingleOrDefaultAsync(m => m.Id == id);

            if (vowel == null)
            {
                return NotFound();
            }

            return Ok(vowel);
        }

        // PUT: api/Vowels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVowel([FromRoute] int id, [FromBody] Vowel vowel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vowel.Id)
            {
                return BadRequest();
            }

            _context.Entry(vowel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VowelExists(id))
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

        // POST: api/Vowels
        [HttpPost]
        public async Task<IActionResult> PostVowel([FromBody] Vowel vowel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Vowels.Add(vowel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VowelExists(vowel.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVowel", new { id = vowel.Id }, vowel);
        }

        // DELETE: api/Vowels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVowel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Vowel vowel = await _context.Vowels.SingleOrDefaultAsync(m => m.Id == id);
            if (vowel == null)
            {
                return NotFound();
            }

            _context.Vowels.Remove(vowel);
            await _context.SaveChangesAsync();

            return Ok(vowel);
        }

        private bool VowelExists(int id)
        {
            return _context.Vowels.Any(e => e.Id == id);
        }
    }
}