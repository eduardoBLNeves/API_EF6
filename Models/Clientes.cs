using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_EF6.Models
{
    [Table(name:"clientes_padaria")]
    public class Clientes
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(120)]
        public string Nome { get; set; }
        public DateTime Data_Nascimento { get; set; }

        [NotMapped]
        public string Idade { get; set; }
    }
}
