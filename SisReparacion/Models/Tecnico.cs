using System.ComponentModel.DataAnnotations;

namespace SistemaReparaciones.Models
{
    public class Tecnico
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        public string Apellidos { get; set; } = string.Empty;

        [Required(ErrorMessage = "El NIF es obligatorio")]
        public string NIF { get; set; } = string.Empty;

        public string Movil { get; set; } = string.Empty;
    }
}
