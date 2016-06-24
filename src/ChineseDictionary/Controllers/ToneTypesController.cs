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
    [Route("api/ToneTypes")]
    public class ToneTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToneTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ToneTypes
        [HttpGet]
        public IEnumerable<ToneType> GetToneTypes()
        {
            return _context.ToneTypes;
        }

        // GET: api/ToneTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetToneType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ToneType toneType = await _context.ToneTypes.SingleOrDefaultAsync(m => m.Id == id);

            if (toneType == null)
            {
                return NotFound();
            }

            return Ok(toneType);
        }

        // PUT: api/ToneTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToneType([FromRoute] int id, [FromBody] ToneType toneType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toneType.Id)
            {
                return BadRequest();
            }

            _context.Entry(toneType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToneTypeExists(id))
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

        // POST: api/ToneTypes
        [HttpPost]
        public async Task<IActionResult> PostToneType([FromBody] ToneType toneType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ToneTypes.Add(toneType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ToneTypeExists(toneType.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetToneType", new { id = toneType.Id }, toneType);
        }

        // DELETE: api/ToneTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToneType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ToneType toneType = await _context.ToneTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (toneType == null)
            {
                return NotFound();
            }

            _context.ToneTypes.Remove(toneType);
            await _context.SaveChangesAsync();

            return Ok(toneType);
        }

        private bool ToneTypeExists(int id)
        {
            return _context.ToneTypes.Any(e => e.Id == id);
        }
    }
}