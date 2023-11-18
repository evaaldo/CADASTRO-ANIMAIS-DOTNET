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

        private bool AnimalExists(Guid id)
        {
            return(_context.Animais?.Any(animal => animal.ID == id)).GetValueOrDefault();
        }

    }
}