using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaReparaciones.Models
{
    public class Reparacion
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public TimeSpan Hora { get; set; }

        [Required]
        [Range(0, 999999999)]
        public decimal Coste { get; set; }

        public bool Garantia { get; set; }

        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public int TecnicoId { get; set; }
        public Tecnico? Tecnico { get; set; }

        public int ElectrodomesticoId { get; set; }
        public Electrodomestico? Electrodomestico { get; set; }
    }
}
