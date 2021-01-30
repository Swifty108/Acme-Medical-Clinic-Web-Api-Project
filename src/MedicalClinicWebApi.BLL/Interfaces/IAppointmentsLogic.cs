using MedicalClinicWebApi.BLL.DTOs;
using MedicalClinicWebApi.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalClinicWebApi.BLL.Interfaces
{
    public interface IAppointmentsLogic
    {
        Task<IEnumerable<Appointment>> GetAllApointments(string patientId);
        Task<Appointment> GetAppointmentByID(int appointmentId);
        Task CreateAppointment(AppointmentDTO appointmentDTO);
        Task UpdateAppointment(AppointmentDTO appointment);
        Task DeleteAppointment(int appointmentId);
    }
}
