using MedicalClinicWebApi.BLLDTOs;
using MedicalClinicWebApi.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalClinicWebApi.BLL.Interfaces
{
    public interface ILabOrdersLogic
    {
        Task<IEnumerable<LabOrder>> GetAllLabOrders(string patientId);

        Task<LabOrder> GetLabOrderByID(int labOrderId, string patientId);

        Task<LabOrderDto> CreateLabOrder(LabOrderDto labOrderDto);

        Task UpdateLabOrder(LabOrderDto labOrder);

        Task DeleteLabOrder(int labOrderId);
    }
}