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
    [Route("api/IPAVowels")]
    public class IPAVowelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IPAVowelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/IPAVowels
        [HttpGet]
        public IEnumerable<IPAVowel> GetIPAVowels()
        {
            return _context.IPAVowels;
        }

        // GET: api/IPAVowels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIPAVowel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IPAVowel iPAVowel = await _context.IPAVowels.SingleOrDefaultAsync(m => m.Id == id);

            if (iPAVowel == null)
            {
                return NotFound();
            }

            return Ok(iPAVowel);
        }

        // PUT: api/IPAVowels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIPAVowel([FromRoute] int id, [FromBody] IPAVowel iPAVowel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != iPAVowel.Id)
            {
                return BadRequest();
            }

            _context.Entry(iPAVowel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IPAVowelExists(id))
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

        // POST: api/IPAVowels
        [HttpPost]
        public async Task<IActionResult> PostIPAVowel([FromBody] IPAVowel iPAVowel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.IPAVowels.Add(iPAVowel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IPAVowelExists(iPAVowel.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIPAVowel", new { id = iPAVowel.Id }, iPAVowel);
        }

        // DELETE: api/IPAVowels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIPAVowel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IPAVowel iPAVowel = await _context.IPAVowels.SingleOrDefaultAsync(m => m.Id == id);
            if (iPAVowel == null)
            {
                return NotFound();
            }

            _context.IPAVowels.Remove(iPAVowel);
            await _context.SaveChangesAsync();

            return Ok(iPAVowel);
        }

        private bool IPAVowelExists(int id)
        {
            return _context.IPAVowels.Any(e => e.Id == id);
        }
    }
}