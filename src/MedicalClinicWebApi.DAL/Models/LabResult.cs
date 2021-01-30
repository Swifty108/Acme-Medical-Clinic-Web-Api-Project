using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalClinicWebApi.DAL.Models
{
    public class LabResult
    {
        [Key]
        public int LabResultId { get; set; }
        public string Notes { get; set; }

        [Column(TypeName = "SmallDateTime")]
        public DateTime ResultsDate { get; set; }
        public int LabOrderId { get; set; }
        public LabOrder LabOrder { get; set; }

    }
}