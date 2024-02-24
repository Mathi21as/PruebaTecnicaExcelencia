using Microsoft.AspNetCore.Mvc;
using PacientesCRUD.Dtos;
using PacientesCRUD.Mappers;
using PacientesCRUD.Models;

namespace PruebaTecnica.Controllers
{
    public class PatientsController : Controller
    {
        private PatientDatabaseContext _patientDatabaseContext;
        private MapEntityToDto mapEntityToDto = new MapEntityToDto();

        public PatientsController(PatientDatabaseContext patientDatabaseContext)
        {
            _patientDatabaseContext = patientDatabaseContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            List<PatientDto> result = _patientDatabaseContext.Patients.Select(p => mapEntityToDto.Patient(p)).ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult Get(long id)
        {
            PatientDto patientDto = mapEntityToDto.Patient(_patientDatabaseContext.GetById(id));
            if (patientDto == null)
                return View();
            return View(patientDto);
        }

        [HttpGet]
        public ActionResult GetByLastname()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetByLastname(string lastname)
        {
            List<PatientEntity> patientsEntity = _patientDatabaseContext.Patients.Where(p => p.lastname == lastname).ToList();
            List<PatientDto> patientsDto = mapEntityToDto.Patient(patientsEntity);
            if (patientsDto == null)
            {
                return new NotFoundObjectResult("No se encontro un paciente con el apellido: " + lastname);
            }
            return View(patientsDto);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreatePatientDto createPatient)
        {
            PatientDto patientDto = mapEntityToDto.Patient(_patientDatabaseContext.Create(createPatient));
            if (patientDto == null)
            {
                return RedirectToAction("Error", "Patients", new { message = "Error al crear paciente." });
            }
            return RedirectToAction("GetPatients", "Patients");
        }

        [HttpGet("get/{id}")]
        public ActionResult Update(long id)
        {
            PatientDto patientDto = mapEntityToDto.Patient(_patientDatabaseContext.GetById(id));
            return View(patientDto);
        }

        [HttpPost]
        public ActionResult Update(PatientDto patientDto)
        {
            PatientDto patientDtoResult = mapEntityToDto.Patient(_patientDatabaseContext.Update(patientDto));
            if (patientDtoResult == null)
            {
                return RedirectToAction("Error", "Patients", new { message = "Error al actualizar paciente" });
            }
            return RedirectToAction("GetPatients", "Patients");
        }

        [HttpGet("{id}")]
        public ActionResult DeleteGet(long id)
        {
            PatientDto patientDto = mapEntityToDto.Patient(_patientDatabaseContext.GetById(id));
            return View(patientDto);
        }

        [HttpPost]
        public ActionResult Delete(PatientDto patientDto)
        {
            bool result = _patientDatabaseContext.Delete(patientDto);

            if (result)
                return RedirectToAction("GetAll", "Patients");
            return RedirectToAction("Error", "Patients", new { message = "Ocurrio un error al eliminar el paciente." });
        }

        [HttpGet]
        public ActionResult Error(string message)
        {
            ViewData["Message"] = message;
            return View();
        }
    }
}
