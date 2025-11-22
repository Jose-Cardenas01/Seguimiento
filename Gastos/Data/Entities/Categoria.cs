using Gastos.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Gastos.Data.Entities
{
    public class Categoria
    {
        [Key]
        public Guid id { get; set; }
        [Required(ErrorMessage = ("El campo {0} es requerido"))]
        [MaxLength(32, ErrorMessage = "El campo {0} no puede superar los {1} caracteres")]
        public required string name { get; set; }
        [Required(ErrorMessage = ("El campo {0} es requerido"))]
        [MaxLength(32, ErrorMessage = "El campo {0} no puede superar los {1} caracteres")]
        public required string description { get; set; }
        public ICollection<Perdidas> gastos{ get; set; } = new List<Perdidas>();
    }
}