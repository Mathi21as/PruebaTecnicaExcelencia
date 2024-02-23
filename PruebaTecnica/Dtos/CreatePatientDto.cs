using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Dtos
{
    public class CreatePatientDto
    {
        [Required (ErrorMessage = "El nombre es obligatorio.")]
        public string firstname { get; set; }
        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string lastname { get; set; }
        [Required(ErrorMessage = "El email es obligatorio.")]
        [RegularExpression("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\\.[a-zA-Z0-9-]+)*$", 
            ErrorMessage = "El email no es valido.")]
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }

    }
}
