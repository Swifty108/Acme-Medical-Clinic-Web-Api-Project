using MedicalClinicWebApi.BLL.DTOs;
using MedicalClinicWebApi.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalClinicWebApi.BLL.Interfaces
{
    public interface ILabResultsLogic
    {
        Task<LabResult> GetLabResult(int labOrderId);
        Task<LabResult> GetLabResultByID(int labResultId);
        Task<LabResultDto> CreateLabResult(LabResultDto labResultDTO);
        Task UpdateLabResult(LabResultDto labResultDTO);
        Task DeleteLabResult(int labResultId);

    }
}
