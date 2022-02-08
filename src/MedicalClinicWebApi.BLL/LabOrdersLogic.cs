using Apartments.DAL.Interfaces;
using AutoMapper;
using MedicalClinicWebApi.BLL.Interfaces;
using MedicalClinicWebApi.BLLDTOs;
using MedicalClinicWebApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalClinicWebApi.BLL
{
    public class LabOrersLogic : ILabOrdersLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LabOrersLogic(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LabOrder>> GetAllLabOrders(string patientId)
        {
            var labOrders = await _unitOfWork.LabOrderRepository.Get(filter: u => u.PatientId == patientId, includeProperties: "Patient").ToListAsync();

            return labOrders.Count == 0 ? null : labOrders;
        }

        public async Task<LabOrder> GetLabOrderByID(int labOrderId, string patientId)
        {
            var labOrder = await _unitOfWork.LabOrderRepository.Get(filter: order => order.LabOrderId == labOrderId && order.PatientId == patientId).FirstOrDefaultAsync();

            return labOrder;
        }

        public async Task<LabOrderDto> CreateLabOrder(LabOrderDto labOrderDto)
        {
            var labOrderEntity = _mapper.Map<LabOrder>(labOrderDto);

            await _unitOfWork.LabOrderRepository.Insert(labOrderEntity);
            await _unitOfWork.Save();

            var createdLabOrder = _mapper.Map<LabOrderDto>(labOrderEntity);

            return createdLabOrder;
        }

        public async Task UpdateLabOrder(LabOrderDto labOrder)
        {
            var labOrderEntity = _mapper.Map<LabOrder>(labOrder);

            _unitOfWork.LabOrderRepository.Update(labOrderEntity);
            await _unitOfWork.Save();
        }

        public async Task DeleteLabOrder(int labOrderId)
        {
            await _unitOfWork.LabOrderRepository.Delete(labOrderId);
            await _unitOfWork.Save();
        }
    }
}