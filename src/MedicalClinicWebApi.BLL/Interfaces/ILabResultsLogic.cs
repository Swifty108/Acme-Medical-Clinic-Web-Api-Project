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
        Task<LabResultDTO> CreateLabResult(LabResultDTO labResultDTO);
        Task UpdateLabResult(LabResultDTO labResultDTO);
        Task DeleteLabResult(int labResultId);

    }
}
