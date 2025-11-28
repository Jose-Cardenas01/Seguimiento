using System.ComponentModel.DataAnnotations;

namespace Gestor_de_Notas.Data.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(32, ErrorMessage = "El campo {0} no puede exceder los {1} caracteres")]
        public string? Name { get; set; }
        public ICollection<Notes>? notes{ get; set; }
    }
}
