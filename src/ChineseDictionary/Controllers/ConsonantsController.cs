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
    [Route("api/Consonants")]
    public class ConsonantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsonantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Consonants
        [HttpGet]
        public IEnumerable<Consonant> GetConsonants()
        {
            return _context.Consonants;
        }

        // GET: api/Consonants/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConsonant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Consonant consonant = await _context.Consonants.SingleOrDefaultAsync(m => m.Id == id);

            if (consonant == null)
            {
                return NotFound();
            }

            return Ok(consonant);
        }

        // PUT: api/Consonants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsonant([FromRoute] int id, [FromBody] Consonant consonant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != consonant.Id)
            {
                return BadRequest();
            }

            _context.Entry(consonant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsonantExists(id))
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

        // POST: api/Consonants
        [HttpPost]
        public async Task<IActionResult> PostConsonant([FromBody] Consonant consonant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Consonants.Add(consonant);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ConsonantExists(consonant.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetConsonant", new { id = consonant.Id }, consonant);
        }

        // DELETE: api/Consonants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsonant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Consonant consonant = await _context.Consonants.SingleOrDefaultAsync(m => m.Id == id);
            if (consonant == null)
            {
                return NotFound();
            }

            _context.Consonants.Remove(consonant);
            await _context.SaveChangesAsync();

            return Ok(consonant);
        }

        private bool ConsonantExists(int id)
        {
            return _context.Consonants.Any(e => e.Id == id);
        }
    }
}