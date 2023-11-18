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
        
    }
}