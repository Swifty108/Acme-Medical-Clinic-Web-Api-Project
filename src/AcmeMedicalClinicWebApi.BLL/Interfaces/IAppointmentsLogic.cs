using AcmeMedicalClinicWebApi.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcmeMedicalClinicWebApi.BLL.Interfaces
{
    public interface IAppointmentsLogic
    {
        public Task<IEnumerable<Appointment>> GetAllApointments(string patientId);
    }
}
