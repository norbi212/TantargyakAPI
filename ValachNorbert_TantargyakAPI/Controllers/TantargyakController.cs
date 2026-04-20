using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ValachNorbert_TantargyakAPI.Data;
using ValachNorbert_TantargyakAPI.DTOs.Tantargy;
using ValachNorbert_TantargyakAPI.Models;

namespace ValachNorbert_TantargyakAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TantargyakController : ControllerBase
    {
        private readonly TantargyContext _context;

        public TantargyakController(TantargyContext context)
        {
            _context = context;
        }

        // GET: api/Tantargyak
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadTantargyDto>>> GetTantargyak()
        {
            var tantargyak = await _context.Tantargyak.Include(t => t.Tanar).ToListAsync();
            return tantargyak.Select(t => MapToDto(t)).ToList();
        }

        // GET: api/Tantargyak/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadTantargyDto>> GetTantargy(int id)
        {
            var tantargy = await _context.Tantargyak.Include(t => t.Tanar).FirstOrDefaultAsync(t => t.Id == id);

            if (tantargy == null)
            {
                return NotFound();
            }

            return MapToDto(tantargy);
        }

        // PUT: api/Tantargyak/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTantargy(int id, UpdateTantargyDto tantargyDto)
        {
            if (id != tantargyDto.Id)
            {
                return BadRequest();
            }

            var tantargy = _context.Tantargyak.Find(id);
            if (tantargy == null) { return NotFound("Nincs ilyen tantárgy"); }

            var tanar = await _context.Tanarok.FirstOrDefaultAsync(t => t.Nev == tantargyDto.TanarNeve);
            if (tanar == null) { return NotFound("Nincs ilyen tanár"); };

            tantargy.TantargyNev = tantargyDto.TantargyNev;
            tantargy.RovidLeiras = tantargyDto.RovidLeiras;
            tantargy.EvesOraszam = tantargyDto.EvesOraszam;
            tantargy.TanarId = tanar.Id;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TantargyExists(id))
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

        // POST: api/Tantargyak
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReadTantargyDto>> PostTantargy(CreateTantargyDto tantargyDto)
        {
            var tantargy = new Tantargy()
            {
                TantargyNev = tantargyDto.TantargyNev,
                RovidLeiras = tantargyDto.RovidLeiras,
                EvesOraszam = tantargyDto.EvesOraszam,
                TanarId = tantargyDto.TanarId
            };
            _context.Tantargyak.Add(tantargy);
            await _context.SaveChangesAsync();

            return Created();
        }

        // DELETE: api/Tantargyak/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTantargy(int id)
        {
            var tantargy = await _context.Tantargyak.FindAsync(id);
            if (tantargy == null)
            {
                return NotFound();
            }

            _context.Tantargyak.Remove(tantargy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TantargyExists(int id)
        {
            return _context.Tantargyak.Any(e => e.Id == id);
        }

        private ReadTantargyDto MapToDto(Tantargy tantargy)
        {
            return new ReadTantargyDto
            {
                Id = tantargy.Id,
                TantargyNev=tantargy.TantargyNev,
                RovidLeiras=tantargy.RovidLeiras,
                EvesOraszam=tantargy.EvesOraszam,
                TanarNeve=tantargy.Tanar.Nev,
            };
        }
    }
}
