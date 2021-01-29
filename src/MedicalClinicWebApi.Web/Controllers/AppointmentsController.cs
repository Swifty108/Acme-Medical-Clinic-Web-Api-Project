using MedicalClinicWebApi.BLL.DTOs;
using MedicalClinicWebApi.BLL.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MedicalClinicWebApi.Web.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        public async Task<IActionResult> Post([FromBody] AppointmentDTO appointment)
        {
            await _appointmentsLogic.CreateAppointment(appointment);

            return Created("", appointment);
        }

        // PUT api/<AppointmentsController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AppointmentDTO appointment)
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
