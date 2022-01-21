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
        Task<LabOrderDto> CreateLabOrder(LabOrderDto labOrderDTO);
        Task UpdateLabOrder(LabOrderDto labOrder);
        Task DeleteLabOrder(int labOrderId);

    }
}
