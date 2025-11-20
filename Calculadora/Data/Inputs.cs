using System.ComponentModel.DataAnnotations;

namespace Calculadora.Data
{
    public class Inputs
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public required float monto { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(0, 100, ErrorMessage = "El {0} debe ser un numero de 0 a 100")]
        public required decimal porcentaje { get; set; }
        public decimal? propina { get; set; } = null;
    }
}
