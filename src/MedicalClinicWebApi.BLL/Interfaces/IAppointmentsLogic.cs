using MedicalClinicWebApi.BLL.DTOs;
using MedicalClinicWebApi.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalClinicWebApi.BLL.Interfaces
{
    public interface IAppointmentsLogic
    {
        public Task CreateAppointment(AppointmentDTO appointmentDTO);
        public Task DeleteAppointment(int appointmentId);
        public Task<IEnumerable<Appointment>> GetAllApointments(string patientId);
        public Task UpdateAppointment(AppointmentDTO appointment);
    }
}
