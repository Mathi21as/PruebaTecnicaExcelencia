using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using PacientesCRUD.Dtos;
using PacientesCRUD.Models;
using System.Net;
using System.Xml.Linq;

namespace PacientesCRUD.Mappers
{
    public class MapEntityToDto
    {
        public PatientDto Patient(PatientEntity patientEntity)
        {
            return new PatientDto()
            {
                Id = patientEntity.id,
                Name = patientEntity.name,
                Lastname = patientEntity.lastname,
                Email = patientEntity.email,
                Phone = patientEntity.phone,
                Address = patientEntity.address,
                Dni = patientEntity.dni
            };
        }

        public List<PatientDto> Patient(List<PatientEntity> patient)
        {
            List<PatientDto> result = new List<PatientDto>();
            foreach (PatientEntity patientEntity in patient) 
            {
                result.Add(new PatientDto()
                {
                    Id = patientEntity.id,
                    Name = patientEntity.name,
                    Lastname = patientEntity.lastname,
                    Email = patientEntity.email,
                    Phone = patientEntity.phone,
                    Address = patientEntity.address,
                    Dni = patientEntity.dni
                });
            }

            return result;
        }
    }
}
