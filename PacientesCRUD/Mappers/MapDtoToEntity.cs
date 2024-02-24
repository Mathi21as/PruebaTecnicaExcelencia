using PacientesCRUD.Dtos;
using PacientesCRUD.Models;

namespace PacientesCRUD.Mappers
{
    public class MapDtoToEntity
    {
        public PatientEntity Patient(PatientDto patientDto)
        {
            return new PatientEntity()
            {
                id = patientDto.Id,
                name = patientDto.Name,
                lastname = patientDto.Lastname,
                email = patientDto.Email,
                phone = patientDto.Phone,
                address = patientDto.Address,
                dni = patientDto.Dni
            };
        }

        public PatientEntity CreatePatient(CreatePatientDto patientDto)
        {
            return new PatientEntity()
            {
                name = patientDto.Name,
                lastname = patientDto.Lastname,
                email = patientDto.Email,
                phone = patientDto.Phone,
                address = patientDto.Address,
                dni = patientDto.Dni
            };
        }
    }
}
