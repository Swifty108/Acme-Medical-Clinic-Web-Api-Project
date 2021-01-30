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
    
    public class RecordsController : ControllerBase
    {
        private readonly IRecordsLogic _recordsLogic;
        private readonly IUserService _userService;

        public RecordsController(IRecordsLogic recordsLogic, IUserService userService)
        {
            _recordsLogic = recordsLogic;
            _userService = userService;
        }

        // GET: api/<AppointmentsController>
        [HttpGet]
        public async Task<IActionResult> Get(string patientId)
        {
            var appointments = await _recordsLogic.GetAllRecords(patientId);

            if (appointments == null)
                return NotFound();

            else
            {
                return Ok(appointments);
            }

        }

        // GET api/<AppointmentsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int recordId)
        {
            var record = await _recordsLogic.GetRecordByID(recordId);

            if (record == null)
                return NotFound();

            else
            {
                return Ok(record);
            }
        }

        // POST api/<AppointmentsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RecordDTO record)
        {

            if (record == null)
            {
                return BadRequest("Record object is null!");
            }

            var patientExists = await _userService.FindUserByID(record.PatientId);

            if(patientExists == null)
            {
                return NotFound("That patient with the supplied patientId could not be found in the database!");
            }
            
            var returnedRecord = await _recordsLogic.CreateRecord(record);

            return Created("", returnedRecord);
        }

        // PUT api/<AppointmentsController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RecordDTO record)
        {
            try
            {
                await _recordsLogic.UpdateRecord(record);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", e.Message });
            }

            return Ok();

        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int recordId)
        {
            await _recordsLogic.DeleteRecord(recordId);

            return Ok();
        }
    }
}
