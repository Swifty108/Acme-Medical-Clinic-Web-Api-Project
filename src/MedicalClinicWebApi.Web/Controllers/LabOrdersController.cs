using MedicalClinicWebApi.BLL.DTOs;
using MedicalClinicWebApi.BLL.Interfaces;
using MedicalClinicWebApi.Common.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalClinicWebApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LabOrdersController : ControllerBase
    {
        private readonly ILabOrdersLogic _labOrdersLogic;
        private readonly IUserService _userService;

        public LabOrdersController(ILabOrdersLogic labOrdersLogic, IUserService userService)
        {
            _labOrdersLogic = labOrdersLogic;
            _userService = userService;
        }

        // GET: api/<AppointmentsController>
        [HttpGet]
        public async Task<IActionResult> Get(string patientId)
        {
            var appointments = await _labOrdersLogic.GetAllLabOrders(patientId);

            if (appointments == null)
                return NotFound();

            else
            {
                return Ok(appointments);
            }

        }

        // GET api/<AppointmentsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int labOrderId)
        {
            var labOrder = await _labOrdersLogic.GetLabOrderByID(labOrderId);

            if (labOrder == null)
                return NotFound();

            else
            {
                return Ok(labOrder);
            }
        }

        // POST api/<AppointmentsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LabOrderDTO labOrder)
        {

            if (labOrder == null)
            {
                return BadRequest("Record object is null!");
            }

            var patientExists = await _userService.FindUserByID(labOrder.PatientId);

            if (patientExists == null)
            {
                return NotFound("That patient with the supplied patientId could not be found in the database!");
            }

            var returnedOrder = await _labOrdersLogic.CreateLabOrder(labOrder);

            return Created("", returnedOrder);
        }

        // PUT api/<AppointmentsController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] LabOrderDTO labOrder)
        {
            try
            {
                await _labOrdersLogic.UpdateLabOrder(labOrder);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", e.Message });
            }

            return Ok();

        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int labOrderId)
        {
            await _labOrdersLogic.DeleteLabOrder(labOrderId);

            return Ok();
        }
    }
}
