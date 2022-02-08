using MedicalClinicWebApi.DAL.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalClinicWebApi.BLLDTOs
{
    public class LabResultDto
    {
        public int LabResultId { get; set; }
        public string Notes { get; set; }

        [Column(TypeName = "SmallDateTime")]
        public DateTime ResultsDate { get; set; }

        public int LabOrderId { get; set; }
        public LabOrder LabOrder { get; set; }
    }
}