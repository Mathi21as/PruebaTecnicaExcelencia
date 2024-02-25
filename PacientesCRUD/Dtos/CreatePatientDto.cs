using System.ComponentModel.DataAnnotations;

namespace PacientesCRUD.Dtos
{
    public class CreatePatientDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "El email es obligatorio.")]
        [RegularExpression("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\\.[a-zA-Z0-9-]+)*$",
            ErrorMessage = "El email no es valido.")]
        public string Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        [Required(ErrorMessage = "El DNI es obligatorio.")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "La edad es obligatoria.")]
        public int Age { get; set; }

        public string? Height { get; set; }

        [Required(ErrorMessage = "El grupo sanguineo es obligatorio.")]
        public string Blood { get; set; }

        public string? Weight { get; set; }

        public bool? IsSmooker { get; set; }

        public bool? IsDrinker { get; set; }

    }
}
