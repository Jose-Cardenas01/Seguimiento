using System.ComponentModel.DataAnnotations;

namespace Gestor_de_Notas.Data.Entities
{
    public class Notes
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(32, ErrorMessage = "El campo {0} no puede exceder los {1} caracteres")]
        public string? Topic { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(400, ErrorMessage = "El campo {0} no puede exceder los {1} caracteres")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.DateTime)]
        public DateTime? Date { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public Guid CategoryId { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public Category? Category { get; set; }
    }
}
