using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalClinicWebApi.BLL.DTOs
{
    public class AppointmentDTO
    { 
        [Column(TypeName = "SmallDateTime")]
        public DateTime AppointmentDateTime { get; set; }
        public string Notes { get; set; }
        public string PatientId { get; set; }
    }
}
