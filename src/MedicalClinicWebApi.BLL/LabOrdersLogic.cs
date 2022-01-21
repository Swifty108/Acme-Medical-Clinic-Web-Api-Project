using Apartments.DAL.Interfaces;
using MedicalClinicWebApi.BLL.DTOs;
using MedicalClinicWebApi.BLL.Interfaces;
using MedicalClinicWebApi.DAL.Identity;
using MedicalClinicWebApi.DAL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

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

        public async Task<LabOrder> GetLabOrderByID(int labOrderId)
        {
            var labOrder = await _unitOfWork.LabOrderRepository.GetByID(labOrderId);
            return labOrder;
        }

        public async Task<LabOrderDto> CreateLabOrder(LabOrderDto labOrderDTO)
        {
            var labOrderEntity = _mapper.Map<LabOrder>(labOrderDTO);

            await _unitOfWork.LabOrderRepository.Insert(labOrderEntity);
            await _unitOfWork.Save();

            var createdLabOrder = _mapper.Map<LabOrderDto>(labOrderEntity);

            return createdLabOrder;
        }

        public async Task UpdateLabOrder(LabOrderDto labOrder)
        {
            var labOrderEntity = _mapper.Map<Record>(labOrder);

            _unitOfWork.RecordRepository.Update(labOrderEntity);
            await _unitOfWork.Save();
        }

        public async Task DeleteLabOrder(int labOrderId)
        {
            await _unitOfWork.AppointmentRepository.Delete(labOrderId);
            await _unitOfWork.Save();
        }
    }
}
