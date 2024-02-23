using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PacientesCRUD.Dtos;

namespace PacientesCRUD.Models
{
    public class PatientDatabaseContext : DbContext
    {
        public PatientDatabaseContext(DbContextOptions<PatientDatabaseContext> options) : base(options)
        {

        }

        public DbSet<PatientEntity> Patients { get; set; }

        public PatientEntity GetById(long id)
        {
            try
            {
                PatientEntity patient = Patients.First(x => x.id == id);
                return patient;
            }
            catch (Exception ex) { return null; }

        }

        public PatientEntity GetByLastname(string lastname)
        {
            
            try
            {
                PatientEntity patient = Patients.First(x => x.lastname == lastname);
                return patient;
            }
            catch (Exception ex) { return null; }

        }

        public PatientEntity Create(CreatePatientDto patientDto)
        {
            PatientEntity patientEntity = new PatientEntity()
            {
                id = null,
                name = patientDto.Name,
                lastname = patientDto.Lastname,
                dni = patientDto.Dni,
                email = patientDto.Email,
                phone = patientDto.Phone,
                address = patientDto.Address
            };
            EntityEntry<PatientEntity> response = Patients.Add(patientEntity);
            SaveChanges();
            return GetById(response.Entity.id ?? throw new Exception("No se pudo crear el paciente"));
        }

        public PatientEntity? Update(PatientDto patientDto)
        {
            PatientEntity patientEntity = Patients.First(x => x.id == patientDto.Id);

            if (patientEntity == null)
            {
                return null;
            }

            patientEntity.name = patientDto.Name;
            patientEntity.lastname = patientDto.Lastname;
            patientEntity.address = patientDto.Address;
            patientEntity.email = patientDto.Email;
            patientEntity.dni = patientDto.Dni;
            patientEntity.phone = patientDto.Phone;

            Patients.Update(patientEntity);
            SaveChanges();

            return patientEntity;
        }

        public bool Delete(PatientDto patientDto)
        {
            PatientEntity patientEntity = new PatientEntity()
            {
                id = null,
                name = patientDto.Name,
                lastname = patientDto.Lastname,
                dni = patientDto.Dni,
                email = patientDto.Email,
                phone = patientDto.Phone,
                address = patientDto.Address
            };

            Patients.Remove(patientEntity);

            return true;
        }

    }
}
