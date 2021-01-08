using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcmeMedicalClinicWebApi.DAL.Models
{
    public class LabOrder
    {
        public int LabOrderId { get; set; }
        public string LabName { get; set; }
        public DateTime OrderDate { get; set; }
        public LabResult Result { get; set; }

        [Required]
        [ForeignKey(nameof(Patient))]
        public string PatientId { get; set; }

        public Patient Patient { get; set; }

    }
}