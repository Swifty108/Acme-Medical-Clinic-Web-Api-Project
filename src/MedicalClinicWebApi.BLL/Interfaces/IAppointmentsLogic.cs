using MedicalClinicWebApi.BLL.DTOs;
using MedicalClinicWebApi.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalClinicWebApi.BLL.Interfaces
{
    public interface IAppointmentsLogic
    {
        public void CreateAppointment(AppointmentDTO appointmentDTO);
        public Task<IEnumerable<Appointment>> GetAllApointments(string patientId);
    }
}
