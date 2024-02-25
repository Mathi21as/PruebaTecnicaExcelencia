namespace PacientesCRUD.Dtos
{
    public class PatientDto
    {
        public long? Id { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string Dni { get; set; }

        public int Age { get; set; }

        public string? Height { get; set; }

        public string Blood { get; set; }

        public string? Weight { get; set; }

        public bool? IsSmooker { get; set; }

        public bool? IsDrinker { get; set; }

    }
}
