using MedicalClinicWebApi.BLL.DTOs;
using MedicalClinicWebApi.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalClinicWebApi.BLL.Interfaces
{
    public interface ILabOrdersLogic
    {
        Task<IEnumerable<LabOrder>> GetAllLabOrders(string patientId);
        Task<LabOrder> GetLabOrderByID(int labOrderId);
        Task<LabOrderDTO> CreateLabOrder(LabOrderDTO labOrderDTO);
        Task UpdateLabOrder(LabOrderDTO labOrder);
        Task DeleteLabOrder(int labOrderId);

    }
}
