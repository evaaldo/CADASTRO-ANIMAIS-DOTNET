using CadastroAnimais.Model;
using Microsoft.EntityFrameworkCore;

namespace CadastroAnimais.Context
{
    public class AnimalContext : DbContext
    {
        public AnimalContext(DbContextOptions<AnimalContext> options) : base(options)
        {

        }

        public DbSet<Animal> Animais { get; set; }
    }
}