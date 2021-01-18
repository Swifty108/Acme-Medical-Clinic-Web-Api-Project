using AcmeApartments.DAL.Interfaces;
using AcmeMedicalClinicWebApi.BLL.Interfaces;
using AcmeMedicalClinicWebApi.DAL.Identity;
using AcmeMedicalClinicWebApi.DAL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcmeMedicalClinicWebApi.BLL
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
        public void CreateAppointment(AppointmentDto appointmentDTO)
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
