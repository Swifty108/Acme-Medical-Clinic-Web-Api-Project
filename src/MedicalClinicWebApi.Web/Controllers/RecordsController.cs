using MedicalClinicWebApi.BLLDTOs;
using MedicalClinicWebApi.BLL.Interfaces;
using MedicalClinicWebApi.Common.Interfaces;
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

        [HttpGet]
        public async Task<IActionResult> Get(string patientId)
        {
            var records = await _recordsLogic.GetAllRecords(patientId);
            return records != null ? Ok(records) : NotFound();
        }

        [HttpGet("{id}/{patientid}")]
        public async Task<IActionResult> Get(int id, string patientId)
        {
            var record = await _recordsLogic.GetRecordByID(id, patientId);
            return record != null ? Ok(record) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RecordDto record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Record object is invalid!");
            }

            var patientExists = await _userService.FindUserByID(record.PatientId);

            if (patientExists == null)
            {
                return NotFound("That patient with the supplied patientId could not be found in the database!");
            }

            var returnedRecord = await _recordsLogic.CreateRecord(record);

            return Created("", returnedRecord);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RecordDto record)
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _recordsLogic.DeleteRecord(id);

            return Ok();
        }
    }
}