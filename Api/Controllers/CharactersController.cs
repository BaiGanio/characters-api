using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly CharactersDbContext _context;

        public CharactersController(CharactersDbContext context)
        {
            _context = context;
        }

        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> Get()
        {
            return await _context.Characters.ToListAsync();
        }

        // GET: api/Characters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> Get(Guid id)
        {
            var character = await _context.Characters.FindAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            return character;
        }

        // PUT: api/Characters/5
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]DTO entry)
        {
            try
            {
                var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id.ToString() == entry.Id);
                if (character != null)
                {
                    character.Likes++;
                    _context.Entry(character).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok($"Liked character {character.Name}");
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // POST: api/Characters
        [HttpPost]
        public async Task<ActionResult> Create(Character entry)
        {
            if (CharacterExists(entry.CharId))
            {
                return BadRequest($"Character with id: {entry.CharId} is already saved...");
            }
            var character = new Character()
            {
                Id  =new Guid(),
                CharId = entry.CharId,
                Name = entry.Name,
                Avatar = entry.Avatar,
                Origin = entry.Origin,
                Species = entry.Species,
                Status = entry.Status,
                Likes = 0,
                CreatedOn = DateTime.Now,
            };
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            return Ok(character);
        }

        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterExists(Guid id)
        {
            return _context.Characters.Any(e => e.Id == id);
        }
        private bool CharacterExists(int charId)
        {
            return _context.Characters.Any(e => e.CharId == charId);
        }
    }
}
