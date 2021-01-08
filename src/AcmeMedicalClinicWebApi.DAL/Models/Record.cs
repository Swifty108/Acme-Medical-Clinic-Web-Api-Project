using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcmeMedicalClinicWebApi.DAL.Models
{
    public class Record
    {
        public int RecordId { get; set; }
        public string Notes { get; set; }
        public DateTime DateCreated { get; set; }

        [Required]
        [ForeignKey(nameof(Patient))]
        public string PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}