using MedicalClinicWebApi.BLL.DTOs;
using MedicalClinicWebApi.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalClinicWebApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentsLogic _appointmentsLogic;

        public AppointmentsController(IAppointmentsLogic appointmentsLogic)
        {
            _appointmentsLogic = appointmentsLogic;
        }

        // GET: api/<AppointmentsController>
        [HttpGet]
        public async Task<IActionResult> Get(string patientId)
        {
            var appointments = await _appointmentsLogic.GetAllApointments(patientId);

            if (appointments == null)
                return NotFound();

            else
            {
                return Ok(appointments);
            }

        }

        // GET api/<AppointmentsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AppointmentsController>
        [HttpPost]
        public IActionResult Post([FromBody] AppointmentDTO appointment)
        {
            _appointmentsLogic.CreateAppointment(appointment);

            return Created("", appointment);
        }

        // PUT api/<AppointmentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AppointmentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
