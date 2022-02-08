using MedicalClinicWebApi.BLLDTOs;
using MedicalClinicWebApi.BLL.Interfaces;
using MedicalClinicWebApi.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MedicalClinicWebApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentsLogic _appointmentsLogic;
        private readonly IUserService _userService;

        public AppointmentsController(IAppointmentsLogic appointmentsLogic, IUserService userService)
        {
            _appointmentsLogic = appointmentsLogic;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string patientId)
        {
            var appointments = await _appointmentsLogic.GetAllApointments(patientId);
            return appointments != null ? Ok(appointments) : NotFound();
        }

        [HttpGet("{id}/{patientid}")]
        public async Task<IActionResult> Get(int id, string patientId)
        {
            var appointment = await _appointmentsLogic.GetAppointmentByID(id, patientId);
            return appointment != null ? Ok(appointment) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AppointmentDto appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Apppointment object is not valid!");
            }

            var patientExists = await _userService.FindUserByID(appointment.PatientId);

            if (patientExists != null)
            {
                var newAppointment = await _appointmentsLogic.CreateAppointment(appointment);
                return Created("", newAppointment);
            }

            return NotFound("That patient with the supplied patientId could not be found in the database!");
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AppointmentDto appointment)
        {
            try
            {
                await _appointmentsLogic.UpdateAppointment(appointment);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", e.Message });
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _appointmentsLogic.DeleteAppointment(id);

            return Ok();
        }
    }
}