using System.ComponentModel.DataAnnotations;

namespace CadastroAnimais.Model
{
    public class Animal
    {
        [Required]
        public Guid ID { get; set; }
        [Required]
        public string Nome { get; set; } = string.Empty;
        [Required]
        public string Raca { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}