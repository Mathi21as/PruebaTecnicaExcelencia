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

        [HttpGet]
        public ActionResult GetAll()
        {
            List<PatientDto> result = _patientDatabaseContext.Patients.Select(p => new PatientDto
            {
                Id = p.id,
                Name = p.name,
                Lastname = p.lastname,
                Email = p.email,
                Phone = p.phone,
                Address = p.address,
                Dni = p.dni,
            }).ToList();

            return View(result);
        }

        [HttpGet]
        public ActionResult Get(long id)
        {
            PatientDto patientDto = _patientDatabaseContext.GetById(id);

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
            List<PatientDto> patientsDto = _patientDatabaseContext.Patients.Where(p => p.lastname == lastname).Select(p => new PatientDto 
            { 
                Id = p.id,
                Name = p.name,
                Lastname = p.lastname,
                Email = p.email,
                Phone = p.phone,
                Address = p.address,
                Dni = p.dni,
            })
                .ToList();

            if (patientsDto == null)
                return new NotFoundObjectResult("No se encontro un paciente con el apellido: " + lastname);

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
            PatientDto patientDto = _patientDatabaseContext.Create(createPatient);

            if (patientDto == null)
                return RedirectToAction("Error", "Patients", new { message = "Error al crear paciente." });

            return Redirect("/");
        }

        [HttpGet("get/{id}")]
        public ActionResult Update(long id)
        {
            PatientDto patientDto = _patientDatabaseContext.GetById(id);
            return View(patientDto);
        }

        [HttpPost]
        public ActionResult UpdatePost(PatientDto patientDto)
        {
            PatientDto patientDtoResult = _patientDatabaseContext.Update(patientDto);

            if (patientDtoResult == null)
                return RedirectToAction("Error", "Patients", new { message = "Error al actualizar paciente. El paciente no se encuentra registrado en el sistema." });

            return Redirect("/");
        }

        [HttpGet("{id}")]
        public ActionResult DeleteGet(long id)
        {
            PatientDto patientDto = _patientDatabaseContext.GetById(id);
            return View(patientDto);
        }

        [HttpPost]
        public ActionResult Delete(PatientDto patientDto)
        {
            bool result = _patientDatabaseContext.Delete(patientDto);

            if (result)
                return Redirect("/");

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
