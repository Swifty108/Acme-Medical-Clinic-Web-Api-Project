using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalClinicWebApi.DAL.Models
{
    public class LabOrder
    {
        [Key]
        public int LabOrderId { get; set; }

        public string LabName { get; set; }

        [Column(TypeName = "SmallDateTime")]
        public DateTime OrderDate { get; set; }

        public string Result { get; set; }

        [Required]
        [ForeignKey(nameof(Patient))]
        public string PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}