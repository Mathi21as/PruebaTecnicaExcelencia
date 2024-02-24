using Microsoft.AspNetCore.Mvc;
using PacientesCRUD.Dtos;
using PacientesCRUD.Models;

namespace PruebaTecnica.Controllers
{
    public class PatientsController : Controller
    {
        private PatientDatabaseContext _patientDatabaseContext;

        public PatientsController(PatientDatabaseContext patientDatabaseContext)
        {
            _patientDatabaseContext = patientDatabaseContext;
        }


        public ActionResult GetPatients()
        {
            List<PatientEntity> result = _patientDatabaseContext.Patients.Select(c=>c).ToList();
            return View(result);
        }

        public ActionResult GetPatient(long id)
        {
            PatientEntity patientDto = _patientDatabaseContext.GetById(id);
            if (patientDto == null)
                return new NotFoundObjectResult("No se encontro el id solicitado");
            return View(patientDto);
        }

        public ActionResult GetPatientByLastname(string lastname)
        {
            PatientEntity patientDto = _patientDatabaseContext.GetByLastname(lastname);
            if (patientDto == null)
            {
                return new NotFoundObjectResult("No se encontro un paciente con el apellido: " + lastname);
            }
            return new OkObjectResult(patientDto);
        }

        [HttpPost]
        public ActionResult CreatePatient(CreatePatientDto createPatient)
        {
            PatientEntity patientEntityCreated = _patientDatabaseContext.Create(createPatient);
            return View(patientEntityCreated);
        }

        [HttpPut]
        public ActionResult UpdatePatient(PatientDto patientDto)
        {
            PatientEntity patientEntity = _patientDatabaseContext.Update(patientDto);

            return new OkObjectResult(patientEntity);
        }

        [HttpDelete]
        public ActionResult DeletePatient(PatientDto patientDto)
        {
            bool result = _patientDatabaseContext.Delete(patientDto);
            return new OkObjectResult(result);
        }
    }
}
