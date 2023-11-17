using CadastroAnimais.Context;
using Microsoft.AspNetCore.Mvc;

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
    }
}