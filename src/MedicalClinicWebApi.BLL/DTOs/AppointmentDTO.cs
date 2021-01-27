using System;

namespace MedicalClinicWebApi.BLL.DTOs
{
    public class AppointmentDTO
    {
        public DateTime AppointmentDate { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string Notes { get; set; }
        public string PatientId { get; set; }
    }
}
