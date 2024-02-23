using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Dtos;
using PruebaTecnica.Entities;
using PruebaTecnica.Repositories;

namespace PruebaTecnica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : Controller
    {
        private PatientDatabaseContext _databaseContext;

        public PatientsController(PatientDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }


        [HttpGet]
        public async Task<IActionResult> getPatients()
        {
            var result = _databaseContext.patients.Select(c=>c.toDto()).ToList();
            return new OkObjectResult(result);
        }

        [HttpGet("{id:long}")]
        [ProducesResponseType(200, Type = typeof(PatientDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> getPatient(long id)
        {
            PatientsdbEntity patientDto = await _databaseContext.getById(id);
            return new OkObjectResult(patientDto);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(PatientDto))]
        public async Task<IActionResult> createPatient(CreatePatientDto createPatient)
        {
            return new OkObjectResult("");
        }

        [HttpPut("{id:long}")]
        [ProducesResponseType(200, Type = typeof(PatientDto))]
        public async Task<IActionResult> updatePatient(long id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id:long}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public async Task<IActionResult> deletePatient(long id)
        {
            throw new NotImplementedException();
        }
    }
}
