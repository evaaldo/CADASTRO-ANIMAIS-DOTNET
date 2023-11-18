using CadastroAnimais.Context;
using CadastroAnimais.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroAnimais.Controller
{
    [Route("CadastroAnimais")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly AnimalContext? _context;

        public AnimalController(AnimalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimal()
        {
            if(_context.Animais == null)
            {
                return NotFound();
            }

            return await _context.Animais.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimal(Guid id)
        {
            if(_context.Animais == null)
            {
                return NotFound();
            }

            var animal = await _context.Animais.FindAsync(id);

            if(animal == null)
            {
                return NotFound();
            }

            return animal;
        }

        [HttpPost]
        public async Task<ActionResult<Animal>> PostAnimal(Animal animal)
        {
            if(_context.Animais == null)
            {
                return Problem("Construtor vazio!");
            }

            _context.Animais.Add(animal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimal", new { id = animal.ID}, animal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimal(Guid id, Animal animal)
        {
            if(id != animal.ID)
            {
                return BadRequest();
            }

            _context.Animais.Entry(animal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!AnimalExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(Guid id)
        {
            if(_context.Animais == null)
            {
                return NotFound();
            }

            var animal = await _context.Animais.FindAsync(id);

            if(animal == null)
            {
                return NotFound();
            }

            _context.Animais.Remove(animal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimalExists(Guid id)
        {
            return(_context.Animais?.Any(animal => animal.ID == id)).GetValueOrDefault();
        }

    }
}