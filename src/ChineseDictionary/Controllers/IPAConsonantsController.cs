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
    [Route("api/IPAConsonants")]
    public class IPAConsonantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IPAConsonantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/IPAConsonants
        [HttpGet]
        public IEnumerable<IPAConsonant> GetIPAConsonants()
        {
            return _context.IPAConsonants;
        }

        // GET: api/IPAConsonants/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIPAConsonant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IPAConsonant iPAConsonant = await _context.IPAConsonants.SingleOrDefaultAsync(m => m.Id == id);

            if (iPAConsonant == null)
            {
                return NotFound();
            }

            return Ok(iPAConsonant);
        }

        // PUT: api/IPAConsonants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIPAConsonant([FromRoute] int id, [FromBody] IPAConsonant iPAConsonant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != iPAConsonant.Id)
            {
                return BadRequest();
            }

            _context.Entry(iPAConsonant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IPAConsonantExists(id))
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

        // POST: api/IPAConsonants
        [HttpPost]
        public async Task<IActionResult> PostIPAConsonant([FromBody] IPAConsonant iPAConsonant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.IPAConsonants.Add(iPAConsonant);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IPAConsonantExists(iPAConsonant.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIPAConsonant", new { id = iPAConsonant.Id }, iPAConsonant);
        }

        // DELETE: api/IPAConsonants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIPAConsonant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IPAConsonant iPAConsonant = await _context.IPAConsonants.SingleOrDefaultAsync(m => m.Id == id);
            if (iPAConsonant == null)
            {
                return NotFound();
            }

            _context.IPAConsonants.Remove(iPAConsonant);
            await _context.SaveChangesAsync();

            return Ok(iPAConsonant);
        }

        private bool IPAConsonantExists(int id)
        {
            return _context.IPAConsonants.Any(e => e.Id == id);
        }
    }
}