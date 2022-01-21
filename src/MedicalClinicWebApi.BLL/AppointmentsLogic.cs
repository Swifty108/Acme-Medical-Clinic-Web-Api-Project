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
    public class AppointmentsLogic : IAppointmentsLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentsLogic(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Appointment>> GetAllApointments(string patientId)
        {
            var appointments = await _unitOfWork.AppointmentRepository.Get(filter: u => u.PatientId == patientId, includeProperties: "Patient").ToListAsync();

            return appointments.Count == 0 ? null : appointments;
        }

        public async Task<Appointment> GetAppointmentByID(int appointmentId)
        {
            var appointment = await _unitOfWork.AppointmentRepository.GetByID(appointmentId);
            return appointment;
        }

        public async Task<AppointmentDto> CreateAppointment(AppointmentDto appointment)
        {
            //var apptDateTime = Convert.ToDateTime(appointmentDTO.AppointmentDateTime);
            //appointmentDTO.AppointmentDateTime = apptDateTime;
            var appointmentEntity = _mapper.Map<Appointment>(appointment);
            
            await _unitOfWork.AppointmentRepository.Insert(appointmentEntity);
            await _unitOfWork.Save();

            var appointmenDTO = _mapper.Map<AppointmentDto>(appointmentEntity);
            return appointmenDTO;

        }

        public async Task UpdateAppointment(AppointmentDto appointment)
        {
            var appointmentEntity = _mapper.Map<Appointment>(appointment);

            _unitOfWork.AppointmentRepository.Update(appointmentEntity);
            await _unitOfWork.Save();
        }

        public async Task DeleteAppointment(int appointmentId)
        {
            await _unitOfWork.AppointmentRepository.Delete(appointmentId);
            await _unitOfWork.Save();
        }
    }
}
