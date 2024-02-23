using PruebaTecnica.Dtos;

namespace PruebaTecnica.Entities
{
    public class PatientsdbEntity
    {
        public long id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string dni { get; set; }

        public PatientDto toDto()
        {
            return new PatientDto()
            {
                id = id,
                name = name,
                lastname = lastname,
                email = email,
                phone = phone,
                address = address,
                dni = dni
            };
        }
    }
}
