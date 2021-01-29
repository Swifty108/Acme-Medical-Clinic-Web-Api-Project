using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalClinicWebApi.DAL.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        [Column(TypeName = "SmallDateTime")]
        public DateTime AppointmentDateTime { get; set; }
        public string Notes { get; set; }

        [Required]
        [ForeignKey(nameof(Patient))]
        public string PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}