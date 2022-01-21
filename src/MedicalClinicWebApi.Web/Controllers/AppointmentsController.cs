using MedicalClinicWebApi.BLL.DTOs;
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
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Employee")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentsLogic _appointmentsLogic;
        private readonly IUserService _userService;

        public AppointmentsController(IAppointmentsLogic appointmentsLogic, IUserService userService)
        {
            _appointmentsLogic = appointmentsLogic;
            _userService = userService;
        }

        // GET: api/<AppointmentsController>
        [HttpGet]
        public async Task<IActionResult> Get(string patientId)
        {
            var appointments = await _appointmentsLogic.GetAllApointments(patientId);

            if (appointments == null)
                return NotFound();


            return Ok(appointments);


        }

        [HttpGet("{appointmentid:int}")]
        public async Task<IActionResult> Get(int appointmentId)
        {
            var appointment = await _appointmentsLogic.GetAppointmentByID(appointmentId);

            if (appointment == null)
                return NotFound();

            else
            {
                return Ok(appointment);
            }
        }

        // POST api/<AppointmentsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AppointmentDto appointment)
        {

            if (appointment == null)
            {
                return BadRequest("Apppointment object is null!");
            }

            var patientExists = await _userService.FindUserByID(appointment.PatientId);

            if (patientExists == null)
            {
                return NotFound("That patient with the supplied patientId could not be found in the database!");
            }

            await _appointmentsLogic.CreateAppointment(appointment);

            return Created("", appointment);
        }

        // PUT api/<AppointmentsController>/5
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

        [HttpDelete]
        public async Task<ActionResult> Delete(int appointmentId)
        {
            await _appointmentsLogic.DeleteAppointment(appointmentId);

            return Ok();
        }
    }
}
