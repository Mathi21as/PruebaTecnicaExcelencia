using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PacientesCRUD.Dtos;
using PacientesCRUD.Mappers;

namespace PacientesCRUD.Models
{
    public class PatientDatabaseContext : DbContext
    {
        private MapDtoToEntity mapDtoToEntity = new MapDtoToEntity();
        public PatientDatabaseContext(DbContextOptions<PatientDatabaseContext> options) : base(options)
        {

        }

        public DbSet<PatientEntity> Patients { get; set; }

        public PatientEntity? GetById(long id)
        {
            try
            {
                PatientEntity patient = Patients.First(x => x.id == id);
                return patient;
            }
            catch (Exception) { return null; }

        }

        public PatientEntity? GetByLastname(string lastname)
        {
            
            try
            {
                PatientEntity patient = Patients.First(x => x.lastname == lastname);
                return patient;
            }
            catch (Exception) { return null; }

        }

        public PatientEntity? Create(CreatePatientDto patientDto)
        {
            PatientEntity patientEntity = mapDtoToEntity.CreatePatient(patientDto);
            EntityEntry<PatientEntity> response = Patients.Add(patientEntity);
            SaveChanges();
            return GetById(response.Entity.id ?? throw new Exception("No se pudo crear el paciente"));
        }

        public PatientEntity? Update(PatientDto patientDto)
        {
            PatientEntity patientEntity = Patients.First(x => x.id == patientDto.Id);

            

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
            PatientEntity patientEntity = mapDtoToEntity.Patient(patientDto);

            Patients.Remove(patientEntity);
            SaveChanges();

            return true;
        }

    }
}
