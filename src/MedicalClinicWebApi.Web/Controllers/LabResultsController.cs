using MedicalClinicWebApi.BLLDTOs;
using MedicalClinicWebApi.BLL.Interfaces;
using MedicalClinicWebApi.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedicalClinicWebApi.Web.Controllers
{
    [Route("api/laborders/{laborderid}/results")]
    [ApiController]
    public class LabResultsController : ControllerBase
    {
        private readonly ILabResultsLogic _labResultsLogic;
        private readonly ILabOrdersLogic _labOrdersLogic;

        public LabResultsController(ILabResultsLogic labResultsLogic, ILabOrdersLogic labOrdersLogic, IUserService userService)
        {
            _labResultsLogic = labResultsLogic;
            _labOrdersLogic = labOrdersLogic;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int labOrderId, string patientId)
        {
            var labOrder = await _labOrdersLogic.GetLabOrderByID(labOrderId, patientId);
            return labOrder != null ? Ok(labOrder) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LabResultDto labResultDto, int labOrderId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Result object is invalid!");
            }

            labResultDto.LabOrderId = labOrderId;
            var returnedLabResult = await _labResultsLogic.CreateLabResult(labResultDto);

            return Created("", returnedLabResult);
        }
    }
}