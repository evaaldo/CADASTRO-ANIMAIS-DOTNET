using CadastroAnimais.Model;
using Microsoft.EntityFrameworkCore;

namespace CadastroAnimais.Context
{
    public class AnimaisContext : DbContext
    {
        public AnimaisContext(DbContextOptions<AnimaisContext> options) : base(options)
        {

        }

        DbSet<Animal> Animais { get; set; }
    }
}