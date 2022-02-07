﻿using MedicalClinicWebApi.BLL.DTOs;
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
        public async Task<IActionResult> Get(int labOrderId)
        {
            var labResult = await _labResultsLogic.GetLabResult(labOrderId);

            if (labResult == null)
                return NotFound();
            else
            {
                return Ok(labResult);
            }
        }

        [HttpGet("{labresultid}")]
        public async Task<IActionResult> GetByID(int labResultId)
        {
            var labOrder = await _labResultsLogic.GetLabResultByID(labResultId);

            if (labOrder == null)
                return NotFound();
            else
            {
                return Ok(labOrder);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LabResultDto labResultDTO)
        {
            if (labResultDTO == null)
            {
                return BadRequest("Result object is null!");
            }

            var labOrder = _labOrdersLogic.GetLabOrderByID(labResultDTO.LabOrderId);

            if (labOrder == null)
            {
                return NotFound("That laborder could not be found!");
            }

            var returnedLabResult = await _labResultsLogic.CreateLabResult(labResultDTO);

            return Created("", returnedLabResult);
        }
    }
}