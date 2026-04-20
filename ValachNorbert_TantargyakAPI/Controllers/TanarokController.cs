using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ValachNorbert_TantargyakAPI.Data;
using ValachNorbert_TantargyakAPI.DTOs.Tanar;
using ValachNorbert_TantargyakAPI.Models;

namespace ValachNorbert_TantargyakAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TanarokController : ControllerBase
    {
        private readonly TantargyContext _context;

        public TanarokController(TantargyContext context)
        {
            _context = context;
        }

        // GET: api/Tanarok
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tanar>>> GetTanarok()
        {
            return await _context.Tanarok.ToListAsync();
        }

        // GET: api/Tanarok/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tanar>> GetTanar(int id)
        {
            var tanar = await _context.Tanarok.FindAsync(id);

            if (tanar == null)
            {
                return NotFound();
            }

            return tanar;
        }

        // PUT: api/Tanarok/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTanar(int id, Tanar tanar)
        {
            if (id != tanar.Id)
            {
                return BadRequest();
            }

            _context.Entry(tanar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TanarExists(id))
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

        // POST: api/Tanarok
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tanar>> PostTanar(CreateTanarDto tanarDto)
        {
            if (tanarDto == null)
            {
                return BadRequest();
            }

            var tanar = new Tanar()
            {
                Nev = tanarDto.Nev,
                Email = tanarDto.Email,
                BelepesDatuma = tanarDto.BelepesDatuma,
            };
            _context.Tanarok.Add(tanar);
            await _context.SaveChangesAsync();

            return Created();
        }

        // DELETE: api/Tanarok/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTanar(int id)
        {
            var tanar = await _context.Tanarok.FindAsync(id);
            if (tanar == null)
            {
                return NotFound();
            }

            _context.Tanarok.Remove(tanar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TanarExists(int id)
        {
            return _context.Tanarok.Any(e => e.Id == id);
        }
    }
}
