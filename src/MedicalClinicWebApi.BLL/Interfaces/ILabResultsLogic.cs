using MedicalClinicWebApi.BLLDTOs;
using MedicalClinicWebApi.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalClinicWebApi.BLL.Interfaces
{
    public interface ILabResultsLogic
    {
        Task<LabResult> GetLabResult(int labOrderId);

        Task<LabResult> GetLabResultByID(int labResultId);

        Task<LabResultDto> CreateLabResult(LabResultDto labResultDto);

        Task UpdateLabResult(LabResultDto labResultDto);

        Task DeleteLabResult(int labResultId);
    }
}