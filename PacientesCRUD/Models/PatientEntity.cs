namespace PacientesCRUD.Models
{
    public class PatientEntity
    {
        public long? id { get; set; }

        public string name { get; set; }

        public string lastname { get; set; }

        public string email { get; set; }

        public string? phone { get; set; }

        public string? address { get; set; }

        public string dni { get; set; }

    }
}
