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

namespace MedicalClinicWebApi.BLL
{
    public class AppointmentsLogic : IAppointmentsLogic
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentsLogic(UserManager<AppUser> userManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Appointment>> GetAllApointments(string patientId)
        {
            var appointments = await _unitOfWork.AppointmentRepository.Get(u => u.PatientId == patientId).ToListAsync();

            return appointments.Count == 0 ? null : appointments;
        }
        public void CreateAppointment(AppointmentDTO appointmentDTO)
        {
            var appointmentEntity = _mapper.Map<Appointment>(appointmentDTO);
            _unitOfWork.AppointmentRepository.Insert(appointmentEntity);
            _unitOfWork.Save();
        }

        //public async Task<IdentityResult> UpdateAppointment(RegisterEmployeeModel model)
        //{

        //}

        //public async Task<IdentityResult> DeleteApointment(RegisterEmployeeModel model)
        //{

        //}


    }
}
