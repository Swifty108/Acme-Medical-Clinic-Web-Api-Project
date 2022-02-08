using MedicalClinicWebApi.BLLDTOs;
using MedicalClinicWebApi.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalClinicWebApi.BLL.Interfaces
{
    public interface IAppointmentsLogic
    {
        Task<IEnumerable<Appointment>> GetAllApointments(string patientId);

        Task<Appointment> GetAppointmentByID(int appointmentId, string patientId);

        Task<AppointmentDto> CreateAppointment(AppointmentDto appointmentDto);

        Task UpdateAppointment(AppointmentDto appointment);

        Task DeleteAppointment(int appointmentId);
    }
}