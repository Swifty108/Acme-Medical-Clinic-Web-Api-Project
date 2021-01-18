using System;

namespace AcmeMedicalClinicWebApi.BLL.DTOs
{
    class AppointmentDTO
    {
        public DateTime AppointmentDateTime { get; set; }
        public string Notes { get; set; }
        public int PatientId { get; set; }
    }
}
