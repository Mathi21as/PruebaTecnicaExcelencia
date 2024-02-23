using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Entities;

namespace PruebaTecnica.Repositories
{
    public class PatientDatabaseContext : DbContext
    {
        public PatientDatabaseContext(DbContextOptions<PatientDatabaseContext> options) : base(options)
        {

        }

        public DbSet<PatientsdbEntity> patients {  get; set; }

        public async Task<PatientsdbEntity> getById(long id)
        {
            PatientsdbEntity patient = await patients.FirstAsync(x => x.id == id);

            return patient;
        }

    }
}
