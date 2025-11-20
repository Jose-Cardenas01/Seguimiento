using System.ComponentModel.DataAnnotations;

namespace Tareas.DTOs
{
    public class TareaDTO
    {
        public required Guid Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(32, ErrorMessage = "El campo {0} no puede superar los {1} caracteres")]
        public required string Title { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede superar los {1} caracteres")]
        public required string Description { get; set; }
        public DateTime DateFinish { get; set; }
        public required DateTime DateInitial { get; set; }
        public required bool State { get; set; } = true;

    }
}
