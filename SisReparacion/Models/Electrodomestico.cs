using System.ComponentModel.DataAnnotations;

namespace SistemaReparaciones.Models
{
    public class Electrodomestico
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El tipo es obligatorio")]
        public string Tipo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El modelo es obligatorio")]
        public string Modelo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, 999999999)]
        public decimal Precio { get; set; }
    }
}

