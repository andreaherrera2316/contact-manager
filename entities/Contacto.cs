using System.ComponentModel.DataAnnotations;

namespace DigitalSolutions.Entities
{
    public class Contacto
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre solo puede contener letras y espacios.")]
        public required string Nombre { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email no válido.")]
        public required string Email { get; set; }

        [Required]
        [RegularExpression(@"^[0-9\+\-\(\)\s]+$", ErrorMessage = "El teléfono solo puede contener números y caracteres de teléfono válidos (+, -, (), espacios).")]
        [MaxLength(15, ErrorMessage = "El teléfono no puede tener más de 15 caracteres.")]
        public required string Telefono { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Nombre: {Nombre}, Teléfono: {Telefono}, Email: {Email}";
        }
    }
}
