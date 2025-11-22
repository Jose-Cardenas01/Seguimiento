using System.ComponentModel.DataAnnotations;

namespace Gastos.Data.Entities
{
    public class Perdidas
    {
        [Key]
        public Guid id { get; set; }
        [Required(ErrorMessage = "El campo {0} debe ser rellenado")]
        public float Monto { get; set; }
        [Required(ErrorMessage = "El campo {0} debe ser rellenado")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede exceder los {1} caracteres")]
        public required string descripcion { get; set; }
        [Required(ErrorMessage = "El campo {0} debe ser rellenado")]
        public DateTime fecha { get; set; }
        public Guid CategoriaID { get; set; }
        public Categoria? category { get; set; }
    }
}
